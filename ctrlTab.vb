
Imports System.Net.NetworkInformation
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports System.Threading
Imports System.Diagnostics

Public Class ctrlTab

    Dim strHostName As String
    Dim strTarget As String
    Dim HostName As IPHostEntry
    Dim IP As IPAddress()

    Dim intSequence As Integer
    Dim intPingTotalTime As Integer
    Dim intPingTotalSuccessful As Integer
    Dim intPingMinTime As Integer
    Dim intPingMaxTime As Integer
    Dim intPingTotalLost As Integer

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        'Make sure our timeout and delay values aren't crazy
        If txtDelay.Text > 3600000 Or txtDelay.Text < 100 Then
            MessageBox.Show("Please enter a delay between 100 ms and 3,600,000 ms (1 hour).", "Error")
            Exit Sub
        End If
        If txtTimeout.Text > 10000 Or txtTimeout.Text < 100 Then
            MessageBox.Show("Please enter a timeout between 100 ms and 10,000 ms (10 seconds)." & vbCrLf & "Below 100 ms, Microsoft's ping framework tends to ignore the timeout." & vbCrLf & "5000 ms is recommended, or else you may get false failures.", "Error")
            Exit Sub
        End If

        'Make sure we have a host to ping
        If txtHost.Text = "" Or txtHost.Text = "Hostname or IP Address" Then
            MessageBox.Show("Please enter a valid host to ping.", "Error")
            Exit Sub
        End If

        'Save host in a string, in case it's a hostname and not an IP, as we may need it later
        strHostName = txtHost.Text

        'Make sure the host is a valid host
        Select Case Uri.CheckHostName(strHostName)
            Case UriHostNameType.Basic
                MessageBox.Show("Please enter a valid host to ping.", "Error")
                Exit Sub
            Case UriHostNameType.Unknown
                MessageBox.Show("Please enter a valid host to ping.", "Error")
                Exit Sub

            Case UriHostNameType.IPv6
                'Target is just an IPv6 address. Use it.
                strTarget = strHostName

            Case UriHostNameType.IPv4
                'Target is just an IPv4 address. Use it.
                strTarget = strHostName

            Case UriHostNameType.Dns

                'Target is a hostname. Verify hostname and convert to IP.
                Try
                    HostName = Dns.GetHostEntry(strHostName)
                    IP = HostName.AddressList
                    strTarget = IP(0).ToString()

                Catch ex As Exception

                    ConsoleTrace.WriteLine("Error verifying hostname or converting to IP. - " & ex.Message)
                    MessageBox.Show("Error verifying hostname or converting to IP." & vbCrLf & ex.Message, "Error")
                    Exit Sub

                End Try

        End Select

        'Make sure our buttons, textboxes, and tab icons are in the right state
        btnStart.Enabled = False
        btnPause.Enabled = True
        btnResume.Enabled = False
        btnStop.Enabled = True
        btnBrowse.Enabled = False
        txtHost.ReadOnly = True
        txtTimeout.Enabled = False
        txtDelay.Enabled = False
        frmMain.tabMain.SelectedTab.ImageKey = "Green"

        'Reset our statistics
        tsslMinTime.Text = "Min. Time: --"
        tsslMaxTime.Text = "Max. Time: --"
        tsslAverageTime.Text = "Average Time: --"
        tsslTotalLost.Text = "Total Lost: --"
        tsslPercentageLost.Text = "Percentage Lost: --"
        tsslTotalPings.Text = "Total Pings: 0"
        intPingTotalSuccessful = 0
        intPingTotalTime = 0
        intPingTotalLost = 0
        intPingMaxTime = vbNull
        intPingMinTime = vbNull

        'Change the tab text to match the host
        frmMain.tabMain.SelectedTab.Text = txtHost.Text

        'Reset txtPath if we are running a new test in the same window
        'Make sure the string is long enough first
        If txtPath.Text.Length > 4 Then

            'Check to see if it ends in .txt
            If txtPath.Text.Substring(txtPath.Text.Length - 4) = ".txt" Then

                'Clear everything past the last backslash
                txtPath.Text = txtPath.Text.Substring(0, txtPath.Text.LastIndexOf("\") + 1)

            End If

        End If

        'Add filename to the filepath, and replace any colons due to possible IPv6 hosts
        txtPath.Text = txtPath.Text & strHostName.Replace(":", "-") & " - " & DateTime.Now.ToString("yyyy-MM-dd - HH-mm-ss") & ".txt"

        'Create our log file
        Directory.CreateDirectory(Path.GetDirectoryName(txtPath.Text))
        Dim ResultsFile As FileStream = File.Create(txtPath.Text)
        Dim ResultsHeader As Byte() = New UTF8Encoding(True).GetBytes("Number" & vbTab & "Host" & vbTab & "Date and Time" & vbTab & "Latency (ms)" & vbTab & "Status" & vbCrLf)
        ResultsFile.Write(ResultsHeader, 0, ResultsHeader.Length)
        ResultsFile.Close()

        'Clear the old results if there are any
        dgResults.Rows.Clear()
        dgResults.Refresh()

        'Start the ping loop
        intSequence = 1
        Dim TimerThread As Thread
        TimerThread = New Thread(AddressOf PingTimer)
        TimerThread.Start()

    End Sub

    Private Sub txtHost_GotFocus(sender As Object, e As EventArgs) Handles txtHost.GotFocus

        'Clear the textbox if it has the default text
        If txtHost.Text = "Hostname or IP Address" Then
            txtHost.Text = ""
            txtHost.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtHost_LostFocus(sender As Object, e As EventArgs) Handles txtHost.LostFocus

        'If there's nothing in the textbox, put it back to the default text
        If txtHost.Text = "" Then
            txtHost.Text = "Hostname or IP Address"
            txtHost.ForeColor = Color.Gray
            frmMain.tabMain.SelectedTab.Text = "Ping"
        End If

    End Sub

    Private Sub BtnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click

        'Make sure our buttons, textboxes, and tab icons are in the right state
        btnStart.Enabled = False
        btnPause.Enabled = False
        btnResume.Enabled = True
        btnStop.Enabled = True
        btnBrowse.Enabled = False
        txtTimeout.Enabled = True
        txtDelay.Enabled = True
        frmMain.tabMain.SelectedTab.ImageKey = "Yellow"

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        'Confirm we want to stop
        Dim Result As DialogResult
        Result = MessageBox.Show("Are you sure you want to stop?" & vbCrLf & "Additional results will require a new ping test.", "Warning", MessageBoxButtons.OKCancel)

        'If we do want to stop, then stop
        If Result = DialogResult.OK Then

            'Make sure our buttons, textboxes, and tab icons are in the right state
            btnStart.Enabled = True
            btnPause.Enabled = False
            btnResume.Enabled = False
            btnStop.Enabled = False
            btnBrowse.Enabled = True
            txtHost.ReadOnly = False
            txtTimeout.Enabled = True
            txtDelay.Enabled = True
            frmMain.tabMain.SelectedTab.ImageKey = "Red"

        End If

    End Sub

    Private Sub BtnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click

        'Make sure our buttons, textboxes, and tab icons are in the right state
        btnStart.Enabled = False
        btnPause.Enabled = True
        btnResume.Enabled = False
        btnStop.Enabled = True
        btnBrowse.Enabled = False
        txtTimeout.Enabled = False
        txtDelay.Enabled = False
        frmMain.tabMain.SelectedTab.ImageKey = "Green"

    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        'Populate txtPath with the resluts of the user picking a folder
        If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then

            'Update the path
            txtPath.Text = FolderBrowserDialog.SelectedPath

            'Correct for possible missing backslash at the end
            If txtPath.Text.EndsWith("\") = False Then
                txtPath.Text = txtPath.Text & "\"
            End If

        End If

    End Sub

    Private Sub PingTimer()

        Dim Request As Ping = New Ping()
        Dim Reply As PingReply
        Dim CurrentDateTime As String
        Dim AppendText As String
        Dim CurrentPercentage As Integer
        Dim TimerThread As Thread

        'We definitely need to use Try, since this is an async method and it may fail halfway through
        Try

            'Check to see if we should stop
            If btnStart.Enabled = True Then
                Exit Sub
            End If

            'Check to see if we should pause
            If btnResume.Enabled = True Then
                Threading.Thread.Sleep(500)
                TimerThread = New Thread(AddressOf PingTimer)
                TimerThread.Start()
                Exit Sub
            End If

            'Get the current time, and send a ping
            CurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss")
            Reply = Request.Send(strTarget, CInt(txtTimeout.Text))

            'Open the output file
            Dim AppendWriter As StreamWriter
            AppendWriter = New StreamWriter(txtPath.Text, True)

            If Reply.Status = 0 Then

                'If it worked, then update the datagrid and append the output file
                dgResults.Invoke(Sub() dgResults.Rows.Add(intSequence.ToString, Reply.Address.ToString, CurrentDateTime, Reply.RoundtripTime.ToString("0"), Reply.Status.ToString))
                AppendText = intSequence.ToString & vbTab & Reply.Address.ToString & vbTab & CurrentDateTime & vbTab & Reply.RoundtripTime.ToString("0") & vbTab & Reply.Status.ToString
                AppendWriter.WriteLineAsync(AppendText)

                'Don't auto-highlight the first row, if this is the first ping.
                'Not sure why DataGridView does this when you create your first row.
                'Also take this time to set our Total Lost label to "0" instead of "--"
                If intSequence = 1 Then
                    dgResults.ClearSelection()
                    tsslTotalLost.Text = "Total Lost: 0"
                End If

                'Update Total and Average statistics
                tsslTotalPings.Text = "Total Pings: " & CStr(intSequence)
                intPingTotalTime = intPingTotalTime + CInt(Reply.RoundtripTime)
                intPingTotalSuccessful = intPingTotalSuccessful + 1
                tsslAverageTime.Text = "Average Time: " & CStr(Math.Round(intPingTotalTime / intPingTotalSuccessful)) 'Rounded to nearest whole number
                CurrentPercentage = (intPingTotalLost * 100) / intSequence 'Total lost, times 100, divided by total pings, gives percentage
                tsslPercentageLost.Text = "Percentage Lost: " & CurrentPercentage.ToString("0")

                'Update Max Time statistic
                'Do these need ToString("#") instead? Why did I use that originally?
                If intPingMaxTime = vbNull Then

                    'Our first ping will always update the Max Time label
                    intPingMaxTime = Reply.RoundtripTime
                    tsslMaxTime.Text = "Max. Time: " & intPingMaxTime.ToString

                ElseIf Reply.RoundtripTime > intPingMaxTime Then

                    'If the new ping time is more than the current max, update the label and the ongoing value
                    intPingMaxTime = Reply.RoundtripTime
                    tsslMaxTime.Text = "Max. Time: " & intPingMaxTime.ToString

                End If

                'Update Min Time statistic
                'Do these need ToString("#") instead? Why did I use that originally?
                If intPingMinTime = vbNull Then

                    'Our first ping will always update the Min Time label
                    intPingMinTime = Reply.RoundtripTime
                    tsslMinTime.Text = "Min. Time: " & intPingMinTime.ToString

                ElseIf Reply.RoundtripTime < intPingMinTime Then

                    'If the new ping time is less than the current min, update the label and the ongoing value
                    intPingMinTime = Reply.RoundtripTime
                    tsslMinTime.Text = "Min. Time: " & intPingMinTime.ToString

                End If

            Else

                'If it failed, list what happened in the datagrid and append the output file
                dgResults.Invoke(Sub() dgResults.Rows.Add(intSequence.ToString, strTarget, CurrentDateTime, vbNull, Reply.Status.ToString))
                AppendText = intSequence.ToString & vbTab & strTarget & vbTab & CurrentDateTime & vbTab & "NULL" & vbTab & Reply.Status.ToString
                AppendWriter.WriteLineAsync(AppendText)

                'Update Total, Lost, and Percentage statistics
                tsslTotalPings.Text = "Total Pings: " & CStr(intSequence)
                intPingTotalLost = intPingTotalLost + 1 'Add one to our lost pings counter
                tsslTotalLost.Text = "Total Lost: " & CStr(intPingTotalLost)
                CurrentPercentage = (intPingTotalLost * 100) / intSequence 'Total lost, times 100, divided by total pings, gives percentage
                tsslPercentageLost.Text = "Percentage Lost: " & CurrentPercentage.ToString("0")

            End If

            'Add one to our total pings counter, for the next iteration of the timer
            intSequence = intSequence + 1

            'Close the output file
            AppendWriter.Close()

            'Auto-scroll the datagrid, if selected
            If chkAutoscroll.Checked = True Then
                dgResults.FirstDisplayedScrollingRowIndex = dgResults.RowCount - 1
            End If

            'Wait for our timer and start all over
            Threading.Thread.Sleep(CInt(txtDelay.Text))
            TimerThread = New Thread(AddressOf PingTimer)
            TimerThread.Start()

        Catch ex As Exception

            ConsoleTrace.WriteLine("Error in the PingTimer: " & ex.Message)

        End Try

    End Sub

    Private Sub txtDelay_TextChanged(sender As Object, e As EventArgs) Handles txtDelay.TextChanged

        Dim CharactersAllowed As String = "1234567890"

        Dim theText As String = txtDelay.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtDelay.SelectionStart
        Dim Change As Integer

        Trace.WriteLine("txtdelay_TextChanged got called")

        'Make sure only numbers are entered
        For x As Integer = 0 To txtDelay.Text.Length - 1
            Letter = txtDelay.Text.Substring(x, 1)
            If CharactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        'If necessary, replace unallowed characters, and maintain the proper location
        txtDelay.Text = theText
        txtDelay.Select(SelectionIndex - Change, 0)

    End Sub

    Private Sub txtTimeout_TextChanged(sender As Object, e As EventArgs) Handles txtTimeout.TextChanged

        Dim CharactersAllowed As String = "1234567890"
        Dim theText As String = txtTimeout.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtTimeout.SelectionStart
        Dim Change As Integer

        'Make sure only numbers are entered
        For x As Integer = 0 To txtTimeout.Text.Length - 1
            Letter = txtTimeout.Text.Substring(x, 1)
            If CharactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        'If necessary, replace unallowed characters, and maintain the proper location
        txtTimeout.Text = theText
        txtTimeout.Select(SelectionIndex - Change, 0)

    End Sub

    Private Sub dgResults_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgResults.SortCompare

        'If sorting by Number or Latency, sort numerically instead of alphabetically
        If e.Column.Name = "colNumber" Or e.Column.Name = "colLatency" Then
            e.SortResult = CInt(e.CellValue1).CompareTo(CInt(e.CellValue2))
            e.Handled = True
        End If

    End Sub

    Private Sub ctrlTab_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Because I suck at coding
        CheckForIllegalCrossThreadCalls = False

    End Sub

    Private Sub txtHost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHost.KeyPress

        'Automatically start if the user hits the Enter key
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If btnStart.Enabled = True Then
                BtnStart_Click(sender, e)
            ElseIf btnResume.Enabled = True Then
                BtnResume_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub txtDelay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDelay.KeyPress

        'Automatically start pinging if the user hits the Enter key
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If btnStart.Enabled = True Then
                BtnStart_Click(sender, e)
            ElseIf btnResume.Enabled = True Then
                BtnResume_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub txtTimeout_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTimeout.KeyPress

        'Automatically start pinging if the user hits the Enter key
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If btnStart.Enabled = True Then
                BtnStart_Click(sender, e)
            ElseIf btnResume.Enabled = True Then
                BtnResume_Click(sender, e)
            End If
        End If

    End Sub

End Class
