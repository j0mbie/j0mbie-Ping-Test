Module [Global]

    Public ConsoleTrace As New TextWriterTraceListener(System.Console.Out)
    Public iniSettings As New iniSettingsClass


    Public Class iniSettingsClass

        Public Height As Integer = 416
        Public Width As Integer = 799
        Public AutoScroll As Boolean = True
        Public Delay As Integer = 2000
        Public Timeout As Integer = 5000
        Public OutputPath As String = "C:\Data\Ping Results\"
        Public LockMode As String = "Writeable"

    End Class

End Module
