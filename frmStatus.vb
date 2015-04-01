Public Class frmStatus
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents ClipboardViewer As System.Windows.Forms.PictureBox
    Friend WithEvents lblClipboard As System.Windows.Forms.Label
    Friend WithEvents BackColorViewer As System.Windows.Forms.PictureBox
    Friend WithEvents lblBackColor As System.Windows.Forms.Label
    Friend WithEvents ColorSelector As System.Windows.Forms.ColorDialog
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmdClearClip As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblLoc = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblClipboard = New System.Windows.Forms.Label()
        Me.ClipboardViewer = New System.Windows.Forms.PictureBox()
        Me.BackColorViewer = New System.Windows.Forms.PictureBox()
        Me.lblBackColor = New System.Windows.Forms.Label()
        Me.ColorSelector = New System.Windows.Forms.ColorDialog()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.cmdClearClip = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblLoc
        '
        Me.lblLoc.Location = New System.Drawing.Point(8, 8)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(112, 24)
        Me.lblLoc.TabIndex = 0
        Me.lblLoc.Text = "Location (px):"
        '
        'lblLocation
        '
        Me.lblLocation.BackColor = System.Drawing.Color.White
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocation.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(128, 8)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(128, 24)
        Me.lblLocation.TabIndex = 1
        '
        'lblClipboard
        '
        Me.lblClipboard.Location = New System.Drawing.Point(8, 88)
        Me.lblClipboard.Name = "lblClipboard"
        Me.lblClipboard.Size = New System.Drawing.Size(88, 24)
        Me.lblClipboard.TabIndex = 2
        Me.lblClipboard.Text = "Clipboard:"
        '
        'ClipboardViewer
        '
        Me.ClipboardViewer.BackColor = System.Drawing.Color.White
        Me.ClipboardViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ClipboardViewer.Location = New System.Drawing.Point(128, 88)
        Me.ClipboardViewer.Name = "ClipboardViewer"
        Me.ClipboardViewer.Size = New System.Drawing.Size(128, 128)
        Me.ClipboardViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ClipboardViewer.TabIndex = 3
        Me.ClipboardViewer.TabStop = False
        '
        'BackColorViewer
        '
        Me.BackColorViewer.BackColor = System.Drawing.Color.White
        Me.BackColorViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BackColorViewer.Location = New System.Drawing.Point(128, 48)
        Me.BackColorViewer.Name = "BackColorViewer"
        Me.BackColorViewer.Size = New System.Drawing.Size(128, 24)
        Me.BackColorViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BackColorViewer.TabIndex = 4
        Me.BackColorViewer.TabStop = False
        '
        'lblBackColor
        '
        Me.lblBackColor.Location = New System.Drawing.Point(8, 48)
        Me.lblBackColor.Name = "lblBackColor"
        Me.lblBackColor.Size = New System.Drawing.Size(88, 24)
        Me.lblBackColor.TabIndex = 5
        Me.lblBackColor.Text = "Backcolor:"
        '
        'ColorSelector
        '
        Me.ColorSelector.AnyColor = True
        Me.ColorSelector.Color = System.Drawing.Color.White
        Me.ColorSelector.SolidColorOnly = True
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.White
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage.Location = New System.Drawing.Point(8, 232)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(248, 24)
        Me.lblMessage.TabIndex = 6
        '
        'cmdClearClip
        '
        Me.cmdClearClip.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClearClip.Location = New System.Drawing.Point(16, 136)
        Me.cmdClearClip.Name = "cmdClearClip"
        Me.cmdClearClip.Size = New System.Drawing.Size(88, 56)
        Me.cmdClearClip.TabIndex = 7
        Me.cmdClearClip.Text = "Clear Clipboard"
        '
        'frmStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.ClientSize = New System.Drawing.Size(264, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClearClip, Me.lblMessage, Me.lblBackColor, Me.BackColorViewer, Me.ClipboardViewer, Me.lblClipboard, Me.lblLocation, Me.lblLoc})
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmStatus"
        Me.ShowInTaskbar = False
        Me.Text = "frmStatus"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BackColorViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackColorViewer.Click
        ColorSelector.ShowDialog()
        BackColorViewer.BackColor = ColorSelector.Color
    End Sub

    Private Sub cmdClearClip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearClip.Click
        Clipboard.SetDataObject(New DataObject())
    End Sub

    Private Sub frmStatus_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        InitializeForms()
    End Sub
End Class
