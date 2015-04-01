Public Class frmGrid
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
    Friend WithEvents Grid As System.Windows.Forms.PictureBox
    Friend WithEvents FileOpener As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Menu As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuFromFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuAssign As System.Windows.Forms.MenuItem
    Friend WithEvents MenuFillSquare As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuMoveImage As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSep3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuTransforms As System.Windows.Forms.MenuItem
    Friend WithEvents MenuRotRight As System.Windows.Forms.MenuItem
    Friend WithEvents MenuRotLeft As System.Windows.Forms.MenuItem
    Friend WithEvents MenuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents MenuImageFileToClipboard As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Grid = New System.Windows.Forms.PictureBox()
        Me.Menu = New System.Windows.Forms.ContextMenu()
        Me.MenuFromFile = New System.Windows.Forms.MenuItem()
        Me.MenuSep1 = New System.Windows.Forms.MenuItem()
        Me.MenuAssign = New System.Windows.Forms.MenuItem()
        Me.MenuFillSquare = New System.Windows.Forms.MenuItem()
        Me.MenuSep2 = New System.Windows.Forms.MenuItem()
        Me.MenuMoveImage = New System.Windows.Forms.MenuItem()
        Me.MenuSep3 = New System.Windows.Forms.MenuItem()
        Me.MenuTransforms = New System.Windows.Forms.MenuItem()
        Me.MenuRotRight = New System.Windows.Forms.MenuItem()
        Me.MenuRotLeft = New System.Windows.Forms.MenuItem()
        Me.FileOpener = New System.Windows.Forms.OpenFileDialog()
        Me.MenuCopy = New System.Windows.Forms.MenuItem()
        Me.MenuImageFileToClipboard = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.BackColor = System.Drawing.Color.White
        Me.Grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid.ContextMenu = Me.Menu
        Me.Grid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Grid.Location = New System.Drawing.Point(8, 8)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(32, 24)
        Me.Grid.TabIndex = 0
        Me.Grid.TabStop = False
        '
        'Menu
        '
        Me.Menu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFromFile, Me.MenuImageFileToClipboard, Me.MenuCopy, Me.MenuSep1, Me.MenuAssign, Me.MenuFillSquare, Me.MenuSep2, Me.MenuMoveImage, Me.MenuSep3, Me.MenuTransforms})
        '
        'MenuFromFile
        '
        Me.MenuFromFile.Index = 0
        Me.MenuFromFile.Text = "Insert imagefile to current..."
        '
        'MenuSep1
        '
        Me.MenuSep1.Index = 3
        Me.MenuSep1.Text = "-"
        '
        'MenuAssign
        '
        Me.MenuAssign.Index = 4
        Me.MenuAssign.Text = "Reset all squares to current"
        '
        'MenuFillSquare
        '
        Me.MenuFillSquare.Index = 5
        Me.MenuFillSquare.Text = "Fill current with backcolor"
        '
        'MenuSep2
        '
        Me.MenuSep2.Index = 6
        Me.MenuSep2.Text = "-"
        '
        'MenuMoveImage
        '
        Me.MenuMoveImage.Index = 7
        Me.MenuMoveImage.Text = "Move current  image"
        '
        'MenuSep3
        '
        Me.MenuSep3.Index = 8
        Me.MenuSep3.Text = "-"
        '
        'MenuTransforms
        '
        Me.MenuTransforms.Index = 9
        Me.MenuTransforms.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuRotRight, Me.MenuRotLeft})
        Me.MenuTransforms.Text = "Transform current"
        '
        'MenuRotRight
        '
        Me.MenuRotRight.Index = 0
        Me.MenuRotRight.Text = "Rotate Right"
        '
        'MenuRotLeft
        '
        Me.MenuRotLeft.Index = 1
        Me.MenuRotLeft.Text = "Rotate Left"
        '
        'FileOpener
        '
        Me.FileOpener.Filter = "Bitmap Image (.bmp)|*.bmp"
        Me.FileOpener.Title = "Select Image File..."
        '
        'MenuCopy
        '
        Me.MenuCopy.Index = 2
        Me.MenuCopy.Text = "Copy current to clipboard"
        '
        'MenuImageFileToClipboard
        '
        Me.MenuImageFileToClipboard.Index = 1
        Me.MenuImageFileToClipboard.Text = "Load imagefile to clipboard..."
        '
        'frmGrid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(50, 42)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Grid})
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGrid"
        Me.ShowInTaskbar = False
        Me.Text = "frmGrid"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim srcX, srcY As Integer

    Private Sub Grid_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid.MouseMove
        X = Int(e.X / ImageSize)
        Y = Int(e.Y / ImageSize)
        If (X <> oX Or Y <> oY) Then
            If MovingImage = True Then
                MsgServer = ("(" & srcX & "," & srcY & ") --> (" & X & "," & Y & ")")
            End If
            UpdateStatus(X, Y)
            Render()
        End If
        oX = X
        oY = Y
    End Sub

    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid.MouseDown
        If e.Button = MouseButtons.Left Then
            If LeftMouseToPaste = True Then
                Try
                    InsertImage(ClipBit.Clone, X, Y)
                Catch err As Exception
                    MsgServer = "Error: Clipboard Empty"
                End Try
            Else
                    If MovingImage = True Then
                        MoveImage(srcX, srcY, X, Y)
                        MsgServer = ""
                    End If
            End If
            UpdateStatus(X, Y)
            Render()
        End If
    End Sub

    Private Sub MenuFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFromFile.Click
        FileOpener.ShowDialog()
        If FileOpener.FileName.Length > 0 Then
            Dim c As New Bitmap(FileOpener.FileName)
            InsertImage(New Bitmap(c), X, Y)
            c.Dispose()
            Render()
        End If
        FileOpener.FileName = ""
    End Sub

    Private Sub MenuFillSquare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFillSquare.Click
        ClearSquare(X, Y)
    End Sub

    Private Sub MenuAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAssign.Click
        For ax = 0 To ImagesHorizontal - 1
            For bx = 0 To ImagesVertical - 1
                ImageList(ax, bx) = ImageList(X, Y).Clone
            Next
        Next
        Render()
    End Sub

    Private Sub MenuMoveImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoveImage.Click
        LeftMouseToPaste = False
        MovingImage = True
        srcX = X
        srcY = Y
        MsgServer = ("(" & srcX & "," & srcY & ") --> (?,?)")
    End Sub

    Private Sub MenuRotRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRotRight.Click
        ImageList(X, Y).RotateFlip(RotateFlipType.Rotate90FlipNone)
        Render()
    End Sub

    Private Sub MenuRotLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRotLeft.Click
        ImageList(X, Y).RotateFlip(RotateFlipType.Rotate90FlipXY)
        Render()
    End Sub

    Private Sub frmGrid_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        InitializeForms()
    End Sub

    Private Sub MenuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCopy.Click
        Clipboard.SetDataObject(ImageList(X, Y).Clone, False)
    End Sub

    Private Sub MenuImageFileToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuImageFileToClipboard.Click
        FileOpener.ShowDialog()
        If FileOpener.FileName.Length > 0 Then
            Dim c As New Bitmap(FileOpener.FileName)
            Clipboard.SetDataObject(c.Clone, False)
            c.Dispose()
        End If
        FileOpener.FileName = ""
    End Sub
End Class
