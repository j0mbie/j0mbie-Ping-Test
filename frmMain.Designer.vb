<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.tabMain = New System.Windows.Forms.CustomTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.imgTabIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.TabPage2)
        Me.tabMain.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabMain.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabMain.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark
        Me.tabMain.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabMain.DisplayStyleProvider.CloserColor = System.Drawing.Color.IndianRed
        Me.tabMain.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.DarkRed
        Me.tabMain.DisplayStyleProvider.FocusTrack = False
        Me.tabMain.DisplayStyleProvider.HotTrack = True
        Me.tabMain.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabMain.DisplayStyleProvider.Opacity = 1.0!
        Me.tabMain.DisplayStyleProvider.Overlap = 0
        Me.tabMain.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabMain.DisplayStyleProvider.Radius = 10
        Me.tabMain.DisplayStyleProvider.ShowTabCloser = True
        Me.tabMain.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText
        Me.tabMain.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark
        Me.tabMain.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabMain.HotTrack = True
        Me.tabMain.ImageList = Me.imgTabIcons
        Me.tabMain.Location = New System.Drawing.Point(1, 1)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(779, 375)
        Me.tabMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.ImageIndex = 1
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(771, 346)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ping"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage2.Size = New System.Drawing.Size(771, 346)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Add..."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'imgTabIcons
        '
        Me.imgTabIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgTabIcons.ImageStream = CType(resources.GetObject("imgTabIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTabIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTabIcons.Images.SetKeyName(0, "Green")
        Me.imgTabIcons.Images.SetKeyName(1, "Red")
        Me.imgTabIcons.Images.SetKeyName(2, "Yellow")
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 377)
        Me.Controls.Add(Me.tabMain)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(799, 416)
        Me.Name = "frmMain"
        Me.Text = "j0mbie Ping Test v2.1 - j0mbie.com"
        Me.tabMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents tabMain As CustomTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents CtrlTab1 As ctrlTab
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents imgTabIcons As ImageList
End Class
