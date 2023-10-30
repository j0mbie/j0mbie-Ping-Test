
Imports System.Net.NetworkInformation
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports System.Threading
Imports System.Diagnostics



Public Class frmMain

    Dim ControlArray(0) As ctrlTab
    Dim iniFileStream As New IniFile
    Dim PreviousTabNumber As Integer = 0


    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim bolResults As Boolean = False
        Dim TempFilePath As String

        'Go through each tab and see if there are any results.
        For Each Item In ControlArray
                If Item.dgResults.RowCount > 1 Then
                    bolResults = True
                    Exit For
                End If
            Next

        'If there are results, confirm we want to quit.
        If bolResults = True Then
            If MessageBox.Show("Are you sure you want to quit?" & vbCrLf & "There are currently results in at least one ping test.", "Are you sure?", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            End If
        End If

        'See if we need to output our defaults to the INI file
        If iniSettings.LockMode = "Writeable" Then

            'Update the ongoing iniSettings with the stuff from our last active tab
            iniSettings.Delay = CInt(ControlArray(PreviousTabNumber).txtDelay.Text)
            iniSettings.Timeout = CInt(ControlArray(PreviousTabNumber).txtTimeout.Text)
            iniSettings.AutoScroll = ControlArray(PreviousTabNumber).chkAutoscroll.Checked
            iniSettings.OutputPath = ControlArray(PreviousTabNumber).txtPath.Text

            'Clear everything past the last backslash in the output path, if it includes a filename.
            If iniSettings.OutputPath.EndsWith(".txt") = True Then
                TempFilePath = ControlArray(PreviousTabNumber).txtPath.Text
                iniSettings.OutputPath = TempFilePath.Substring(0, TempFilePath.LastIndexOf("\") + 1)
            End If

            'I don't like the idea of one mis-write INI file setting crashing the entire program close.
            'I'm sure this could be handled better, but for now this will do.
            On Error Resume Next

            'Open up a file stream
            Dim IniFileWriter As New StreamWriter("j0mbie Ping Test Settings.ini")

            'There's surely a way to find an existing line and replace the value. But I don't yet know it.
            'For now, we will just re-create the file, line by line.

            IniFileWriter.WriteLine("[WindowDefaults]")
            IniFileWriter.WriteLine("Height=" & CStr(iniSettings.Height))
            IniFileWriter.WriteLine("Width=" & CStr(iniSettings.Width))
            IniFileWriter.WriteLine("")
            IniFileWriter.WriteLine("[PingDefaults]")
            IniFileWriter.WriteLine("AutoScroll=" & CStr(iniSettings.AutoScroll))
            IniFileWriter.WriteLine("Delay=" & CStr(iniSettings.Delay))
            IniFileWriter.WriteLine("Timeout=" & CStr(iniSettings.Timeout))
            IniFileWriter.WriteLine("OutputPath=" & iniSettings.OutputPath)
            IniFileWriter.WriteLine("")
            IniFileWriter.WriteLine("[SettingsLock]")
            IniFileWriter.WriteLine("LockMode=" & iniSettings.LockMode)
            IniFileWriter.WriteLine(";")
            IniFileWriter.WriteLine(";     Locked: INI file is loaded at program startup.")
            IniFileWriter.WriteLine(";             Every new tab uses the same ping defaults.")
            IniFileWriter.WriteLine(";             Settings are never saved to INI file by the program.")
            IniFileWriter.WriteLine(";")
            IniFileWriter.WriteLine(";      Fluid: INI file is loaded at program startup.")
            IniFileWriter.WriteLine(";             Every new tab uses the defaults from the last active tab.")
            IniFileWriter.WriteLine(";             Settings are never saved to INI file by the program.")
            IniFileWriter.WriteLine(";")
            IniFileWriter.WriteLine(";  Writeable: INI file is loaded at program startup.")
            IniFileWriter.WriteLine(";             Every new tab uses the defaults from the last active tab.")
            IniFileWriter.WriteLine(";             Settings of the active tab are saved back to the INI file at program close.")

            'Close the file stream
            IniFileWriter.Close()

        End If

        'Flush the trace listener.
        Trace.Flush()







        ' *** Uses iniFile.vb ***
        '
        ''Save our settings, unless the INI file told us not, to when we loaded it
        'If iniSettings.LockMode = "Writeable" Then

        '    'Set up our iniFileStream for writing out the INI file
        '    iniFileStream.SetKeyValue("WindowDefaults", "Height", CStr(iniSettings.Height))
        '    iniFileStream.SetKeyValue("WindowDefaults", "Width", CStr(iniSettings.Width))
        '    iniFileStream.SetKeyValue("PingDefaults", "AutoScroll", CStr(iniSettings.AutoScroll))
        '    iniFileStream.SetKeyValue("PingDefaults", "Delay", CStr(iniSettings.Delay))
        '    iniFileStream.SetKeyValue("PingDefaults", "Timeout", CStr(iniSettings.Timeout))
        '    iniFileStream.SetKeyValue("PingDefaults", "OutputPath", iniSettings.OutputPath)
        '    iniFileStream.SetKeyValue("SettingsLock", "LockMode", iniSettings.LockMode)

        '    'Actually write out the INI file to disk
        '    iniFileStream.Save("j0mbie Ping Test Settings.ini")

        'End If

    End Sub

    Private Sub tabMain_TabClosing(sender As Object, e As TabControlCancelEventArgs) Handles tabMain.TabClosing

        'If there are results, confirm we want to close the tab.
        If ControlArray(e.TabPage.Controls.Item(0).Tag).dgResults.RowCount > 1 Then

            'If they answer no, then cancel closing the tab
            If MessageBox.Show("Are you sure you want to close this tab?", "Are you sure?", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            End If

        Else

            If tabMain.TabCount < 3 Then

                'If this is the last tab (besides the Add tab) then close the program
                Me.Close()

            Else

                'Clear the results, so that it doesn't trigger when we close the whole form
                ControlArray(e.TabPage.Controls.Item(0).Tag).dgResults.Rows.Clear()

                'Re-tag the ControlArray items to reflect the new tab order
                Dim i As Integer = e.TabPageIndex
                Do While i < tabMain.TabCount
                    e.TabPage.Controls.Item(0).Tag = i.ToString
                Loop

            End If

        End If

    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged

        Dim intSelectedTab As Integer = tabMain.SelectedIndex
        Dim TempFilePath As String

        'Modify the new tab defaults to reflect the current tab. Skipped if LockMode was set to "Locked", because then the
        'j0mbie Ping Test Settings INI file tells us to use the loaded defaults for every new tab, overriding the previous tab settings.
        If iniSettings.LockMode = "Fluid" Or iniSettings.LockMode = "Writeable" Then

            Trace.WriteLine("Previous Tab number: " & CStr(PreviousTabNumber))
            Trace.WriteLine("Previous Delay value: " & CStr(iniSettings.Delay))

            'Save the old tab settings to our ongoing iniSettings
            iniSettings.AutoScroll = ControlArray(PreviousTabNumber).chkAutoscroll.Checked
            iniSettings.Delay = CInt(ControlArray(PreviousTabNumber).txtDelay.Text)
            iniSettings.Timeout = CInt(ControlArray(PreviousTabNumber).txtTimeout.Text)
            iniSettings.OutputPath = ControlArray(PreviousTabNumber).txtPath.Text

            'Clear everything past the last backslash in the output path, if it includes a filename.
            If iniSettings.OutputPath.EndsWith(".txt") = True Then
                Trace.WriteLine(".txt")
                TempFilePath = ControlArray(PreviousTabNumber).txtPath.Text
                iniSettings.OutputPath = TempFilePath.Substring(0, TempFilePath.LastIndexOf("\") + 1)
            End If

            Trace.WriteLine("Updated iniSettings.")
            Trace.WriteLine("New Delay value: " & CStr(iniSettings.Delay))

        End If


        If tabMain.SelectedTab.Text = "Add..." Then

            'If the user clicked to add a new tab, then we have to create it.

            'Add the custom control to the current "Add..." tab
            Array.Resize(ControlArray, ControlArray.Count + 1)
            ControlArray(intSelectedTab) = New ctrlTab
            ControlArray(intSelectedTab).Location = New Point(0, 0)
            ControlArray(intSelectedTab).Tag = intSelectedTab.ToString
            tabMain.TabPages(intSelectedTab).Controls.Add(ControlArray(intSelectedTab))

            'Modify the new custom control with our defaults
            ControlArray(intSelectedTab).chkAutoscroll.Checked = iniSettings.AutoScroll
            Trace.WriteLine("at this point, inisettings.delay = " & CStr(iniSettings.Delay))
            ControlArray(intSelectedTab).txtDelay.Text = CStr(iniSettings.Delay)
            ControlArray(intSelectedTab).txtTimeout.Text = CStr(iniSettings.Timeout)
            ControlArray(intSelectedTab).txtPath.Text = iniSettings.OutputPath

            'Ensure the new custom control stretches to fit the window
            Call ResizeControls()

            'Change the name and icon of the current "Add..." tab
            tabMain.TabPages(intSelectedTab).Text = "Ping"
            tabMain.TabPages(intSelectedTab).ImageKey = "Red"

            'Add a new blank "Add..." tab
            tabMain.TabPages.Add("Add...")

        End If

        'Our current tab number fills our previous tab number variable, for next time
        PreviousTabNumber = intSelectedTab


    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim NewIniFile As String
        Dim CurrentLine As String

        'Set up console output in .NET 5 for debugging purposes
        Trace.Listeners.Add(ConsoleTrace)
        Trace.WriteLine("Main form loading.")

        'Add our custom control ctrlTab into the control array, then put it on the first tab
        ControlArray(0) = New ctrlTab
        ControlArray(0).Location = New Point(0, 0)
        ControlArray(0).Tag = "0"
        tabMain.TabPages(0).Controls.Add(ControlArray(0))


        'I don't like the idea of one mis-read INI file setting crashing the entire program load.
        'I'm sure this could be handled better, but for now this will do.
        On Error Resume Next

        'Check if the MPT Settings INI file exists.
        If My.Computer.FileSystem.FileExists("j0mbie Ping Test Settings.ini") = False Then

            'If the file doesn't exist, create it using our embedded resource
            NewIniFile = My.Resources.j0mbie_Ping_Test_Settings
            File.WriteAllText("j0mbie Ping Test Settings.ini", NewIniFile)

        Else

            'Open up a file stream so we can read the INI file
            Dim IniFileReader As New StreamReader("j0mbie Ping Test Settings.ini")

            'Read each line
            Do While IniFileReader.EndOfStream = False

                'Read the next line, and trim any random spaces from the end
                CurrentLine = IniFileReader.ReadLine()
                CurrentLine.Trim()

                If CurrentLine.StartsWith("Height=") Then

                    'Read the Window Height value, make sure it's acceptable, and modify the existing window
                    CurrentLine = Replace(CurrentLine, "Height=", "")
                    iniSettings.Height = CInt(CurrentLine)
                    If iniSettings.Height < Me.MinimumSize.Height Then
                        iniSettings.Height = Me.MinimumSize.Height
                    End If
                    Me.Height = iniSettings.Height

                ElseIf CurrentLine.StartsWith("Width=") Then

                    'Read the Window Width value, make sure it's acceptable, and modify the existing window
                    CurrentLine = Replace(CurrentLine, "Width=", "")
                    iniSettings.Width = CInt(CurrentLine)
                    If iniSettings.Width < Me.MinimumSize.Width Then
                        iniSettings.Width = Me.MinimumSize.Width
                    End If
                    Me.Width = iniSettings.Width

                ElseIf CurrentLine.StartsWith("AutoScroll=") Then

                    'Read the Ping Results Auto-Scroll value, make sure it's acceptable, and modify the existing control
                    CurrentLine = Replace(CurrentLine, "AutoScroll=", "")
                    iniSettings.AutoScroll = CBool(CurrentLine)
                    If iniSettings.AutoScroll <> True And iniSettings.AutoScroll <> False Then
                        iniSettings.AutoScroll = True
                    End If
                    ControlArray(0).chkAutoscroll.Checked = iniSettings.AutoScroll

                ElseIf CurrentLine.StartsWith("Delay=") Then

                    'Read the Ping Delay value, make sure it's acceptable, and modify the existing control
                    CurrentLine = Replace(CurrentLine, "Delay=", "")
                    iniSettings.Delay = CInt(CurrentLine)
                    If iniSettings.Delay < 100 Then
                        iniSettings.Delay = 100
                    ElseIf iniSettings.Delay > 3600000 Then
                        iniSettings.Delay = 3600000
                    End If
                    ControlArray(0).txtDelay.Text = CStr(iniSettings.Delay)

                ElseIf CurrentLine.StartsWith("Timeout=") Then

                    'Read the Ping Timeout value, make sure it's acceptable, and modify the existing control
                    CurrentLine = Replace(CurrentLine, "Timeout=", "")
                    iniSettings.Timeout = CInt(CurrentLine)
                    If iniSettings.Timeout < 100 Then
                        iniSettings.Timeout = 100
                    ElseIf iniSettings.Timeout > 10000 Then
                        iniSettings.Timeout = 10000
                    End If
                    ControlArray(0).txtTimeout.Text = CStr(iniSettings.Timeout)

                ElseIf CurrentLine.StartsWith("OutputPath=") Then

                    'Read the Output Path value, make sure it's acceptable, and modify the existing control
                    CurrentLine = Replace(CurrentLine, "OutputPath=", "")
                    iniSettings.OutputPath = CurrentLine
                    If iniSettings.OutputPath = "" Then
                        'Validating the format of a file path, as well as making sure we have permissions to create
                        'it if it doesn't exist, is a whole hornets' nest I don't want to get into. For now, we will
                        'just make sure something isn't blank.
                        iniSettings.OutputPath = "C:\Data\Ping Results\"
                    End If
                    ControlArray(0).txtPath.Text = iniSettings.OutputPath

                ElseIf CurrentLine.StartsWith("LockMode=") Then

                    'Read the Lock Mode value, make sure it's acceptable, and just store it for later use
                    CurrentLine = Replace(CurrentLine, "LockMode=", "")
                    iniSettings.LockMode = CurrentLine
                    Trace.WriteLine(CurrentLine)
                    If iniSettings.LockMode <> "Locked" And iniSettings.LockMode <> "Fluid" And iniSettings.LockMode <> "Writeable" Then
                        iniSettings.LockMode = "Writeable"
                    End If
                End If

            Loop

            'Close the file stream
            IniFileReader.Close()

        End If

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        'Resize all the tabs
        Call ResizeControls()

        'Save the new window size to our current INI settings variable, for possible writing to disk
        If iniSettings.LockMode = "Writeable" And Me.WindowState <> FormWindowState.Minimized Then

            iniSettings.Height = Me.Height
            iniSettings.Width = Me.Width

        End If

    End Sub

    Private Sub ResizeControls()

        'Dynamically resize our form contents, when the form itself is resized.
        'Most of the elements are anchored, but the dynamically created controls (ctrlTab) don't have that property.

        Try

            'Go through each custom control, and resize it
            For Each ctrlTab In ControlArray

                'My math doesn't add up for the buffer factors, so I found them by guess-and-check. :(
                ctrlTab.Width = Me.Width - 25
                ctrlTab.Height = Me.Height - 75

            Next

        Catch ex As Exception

            'If there's a problem, write it in debug output
            Trace.WriteLine("Error in Main Form resize: " & ex.Message)

        End Try

    End Sub

    Private Sub frmMain_Move(sender As Object, e As EventArgs) Handles Me.Move

        Trace.WriteLine("Form X (Left): " & Me.Location.X)
        Trace.WriteLine("Form Width: " & Me.Size.Width)
        Trace.WriteLine("Form Right: " & (Me.Location.X + Me.Size.Width))
        Trace.WriteLine("")
        Trace.WriteLine("Form Y (Top): " & Me.Location.Y)
        Trace.WriteLine("Form Height: " & Me.Size.Height)
        Trace.WriteLine("Form Bottom: " & (Me.Location.Y + Me.Size.Height))
        Trace.WriteLine("")

    End Sub

End Class
