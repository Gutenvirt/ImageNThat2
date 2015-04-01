Module modShared

    Public frmStatus As New frmStatus()
    Public frmGrid As New frmGrid()
    Public frmCommand As New frmCommand()
    Public frmStartup As New frmStartup()

    Public ax, bx, cx As Integer
    Public X, oX, Y, oY As Integer
    Public ImageSize, ImagesVertical, ImagesHorizontal As Integer

    Dim GDI As Graphics

    Public iPen As New Pen(Color.Gray, 1)
    Public iBrush As New SolidBrush(Color.Gray)
    Public iFont As New Font(FontFamily.GenericSansSerif, 12)

    Public ClipBit As Bitmap
    Public ImageList(,) As Bitmap

    Public MsgServer As String = ""

    Public ClipboardInterface As IDataObject = Clipboard.GetDataObject

    Public WasActivated As Boolean = False
    Public WasInitialized As Boolean = False
    Public ResizeImage As Boolean = False
    Public LeftMouseToPaste As Boolean = True
    Public MovingImage As Boolean = False

    Public Sub Terminate()
        Try
            For ax = 0 To ImagesHorizontal - 1
                For bx = 0 To ImagesVertical - 1
                    ImageList(ax, bx).Dispose()
                Next
            Next
            GDI.Dispose()
            ClipBit.Dispose()
            iBrush.Dispose()
            iFont.Dispose()
            iPen.Dispose()
            frmStartup.Dispose()
            frmStatus.Dispose()
            frmGrid.Dispose()
            frmCommand.Dispose()
        Catch err As Exception
            MsgServer = err.ToString
        End Try
    End Sub

    Public Sub Initialize()
        ReDim ImageList(ImagesHorizontal, ImagesVertical)

        InitializeForms()

        ImageList(0, 0) = New Bitmap(ImageSize, ImageSize)
        If ImagesHorizontal > 0 Then
            MoveImage(0, 0, 1, 0)
        Else
            If ImagesVertical > 0 Then
                MoveImage(0, 0, 0, 1)
            Else
                Restart()
                Exit Sub
            End If
        End If

        X = 0 : Y = 0

        frmGrid.MenuAssign.PerformClick()

        LeftMouseToPaste = True
        MovingImage = False
        ResizeImage = False

        WasInitialized = True

        ClipBit = New Bitmap(ImageSize, ImageSize)
        GDI.PageUnit = GraphicsUnit.Pixel
        GDI.SmoothingMode = Drawing.Drawing2D.SmoothingMode.None
        GDI.InterpolationMode = Drawing.Drawing2D.InterpolationMode.Bilinear

        Application.DoEvents()
    End Sub

    Public Sub InitializeForms()
        frmGrid.Grid.Location = New Point(0, 0)
        frmGrid.Grid.Height = ImagesVertical * ImageSize + 2
        frmGrid.Grid.Width = ImagesHorizontal * ImageSize + 2

        If frmGrid.Grid.Height < 5 Then frmGrid.Grid.Height = ImageSize + 2
        If frmGrid.Grid.Width < 5 Then frmGrid.Grid.Width = ImageSize + 2

        frmGrid.StartPosition = FormStartPosition.Manual
        frmGrid.Location = New Point(0, 0)

        While frmGrid.ClientSize.Height < frmGrid.Grid.Height
            If frmGrid.ClientSize.Height >= 500 Then Exit While
            frmGrid.Height += 1
        End While
        While frmGrid.ClientSize.Width < frmGrid.Grid.Width
            If frmGrid.ClientSize.Width >= 500 Then Exit While
            frmGrid.Width += 1
        End While

        frmStatus.StartPosition = FormStartPosition.Manual
        If frmGrid.ClientSize.Height > 500 Then
            frmStatus.Location = New Point(frmGrid.Left + frmGrid.Width + 16, frmGrid.Top)
        Else
            frmStatus.Location = New Point(frmGrid.Left + frmGrid.Width, frmGrid.Top)
        End If

        frmCommand.StartPosition = FormStartPosition.Manual
        If frmGrid.ClientSize.Width > 500 Then
            frmCommand.Location = New Point(frmGrid.Left + frmGrid.Width + 16, frmStatus.Top + frmStatus.Height)
        Else
            frmCommand.Location = New Point(frmGrid.Left + frmGrid.Width, frmStatus.Top + frmStatus.Height)
        End If
        frmCommand.Width = frmStatus.Width
        frmCommand.Height = frmGrid.Height - frmStatus.Height
        If frmCommand.Height < 224 Then frmCommand.Height = 224

        frmGrid.Show()
        frmStatus.Show()
        frmCommand.Show()
    End Sub

    Public Sub UpdateStatus(ByVal gX As Integer, ByVal gY As Integer)
        frmStatus.lblLocation.Text = gX & ", " & gY
        frmStatus.lblMessage.Text = MsgServer
        If LeftMouseToPaste = True Then frmCommand.optLeftMouse.Checked = True
        If LeftMouseToPaste = False Then frmCommand.optLeftMouse.Checked = False
        If ResizeImage = True Then frmCommand.optResize.Checked = True
        If ResizeImage = False Then frmCommand.optResize.Checked = False
        Try
            ClipboardInterface = Clipboard.GetDataObject
            If ClipboardInterface.GetDataPresent(DataFormats.Bitmap) = True Then
                ClipBit = ClipboardInterface.GetData(DataFormats.Bitmap)
                If ClipBit.Width > 254 Or ClipBit.Height > 254 Then
                    ClipBit = New Bitmap(ImageSize, ImageSize)
                Else
                    frmStatus.ClipboardViewer.Image = ClipBit.Clone
                End If
            Else
                frmStatus.ClipboardViewer.CreateGraphics.Clear(Color.White)
                frmStatus.ClipboardViewer.CreateGraphics.DrawString("No Clipboard", iFont, New SolidBrush(Color.Black), 0, 0)
                frmStatus.ClipboardViewer.CreateGraphics.DrawString("Data", iFont, New SolidBrush(Color.Black), 0, 15)
            End If
        Catch err As Exception
            If err.ToString.Length > 0 Then Clipboard.SetDataObject("Error Occured")
        End Try
        Application.DoEvents()
    End Sub

    Public Sub Render()
        If WasInitialized = True Then
            For ax = 0 To ImagesHorizontal - 1
                For bx = 0 To ImagesVertical - 1
                    bx = Math.Max(bx, 0)
                    ax = Math.Max(ax, 0)
                    frmGrid.Grid.CreateGraphics.DrawImageUnscaled(ImageList(ax, bx), ax * ImageSize, bx * ImageSize, ImageSize - 1, ImageSize - 1)
                Next
            Next
            Application.DoEvents()
        End If
    End Sub

    Public Sub InsertImage(ByVal ClipBMP As Bitmap, ByVal gX As Integer, ByVal gY As Integer)
        Try
            GDI = Graphics.FromImage(ImageList(gX, gY))
            If ClipBMP.Height >= ImageSize Or ClipBMP.Width >= ImageSize Then
                GDI.DrawImageUnscaled(ClipBMP, 0, 0, ImageSize - 1, ImageSize - 1)
            End If
            If ClipBMP.Height < ImageSize And ClipBMP.Width < ImageSize Then
                If ResizeImage = False Then
                    Dim HalfWidth As Integer = Int((ImageSize - ClipBMP.Width - 1) / 2)
                    Dim HalfHeight As Integer = Int((ImageSize - ClipBMP.Height - 1) / 2)
                    iBrush.Color = frmStatus.BackColorViewer.BackColor
                    GDI.FillRectangle(iBrush, 0, 0, ImageSize - 1, ImageSize - 1)
                    GDI.DrawImageUnscaled(ClipBMP, HalfWidth, HalfHeight, ClipBMP.Width, ClipBMP.Height)
                Else
                    GDI.DrawImage(ClipBMP, 0, 0, ImageSize - 1, ImageSize - 1)
                End If
            End If
            ClipBMP.Dispose()
        Catch err As Exception
            MsgServer = err.ToString
        End Try
    End Sub

    Public Sub SaveImage(ByVal FileName As String)
        Dim Tilefield As New Bitmap(ImagesHorizontal * ImageSize, ImagesVertical * ImageSize)
        GDI = Graphics.FromImage(Tilefield)
        For ax = 0 To ImagesHorizontal - 1
            For bx = 0 To ImagesVertical - 1
                GDI.DrawImageUnscaled(ImageList(ax, bx), ax * ImageSize, bx * ImageSize, ImageSize - 1, ImageSize - 1)
            Next
        Next
        Tilefield.Save(FileName, Imaging.ImageFormat.Bmp)
        MsgBox("Master Image Saved", MsgBoxStyle.Information, "A System Message...")
        Tilefield.Dispose()
    End Sub

    Public Sub ClearSquare(ByVal gX As Integer, ByVal gY As Integer)
        GDI = Graphics.FromImage(ImageList(gX, gY))
        GDI.FillRectangle(iBrush, 0, 0, ImageSize - 1, ImageSize - 1)
    End Sub

    Public Sub MoveImage(ByVal gX As Integer, ByVal gY As Integer, ByVal nX As Integer, ByVal nY As Integer)
        ImageList(nX, nY) = ImageList(gX, gY).Clone
        GDI = Graphics.FromImage(ImageList(gX, gY))
        GDI.Clear(Color.White)
        GDI.DrawRectangle(iPen, 0, 0, ImageSize - 1, ImageSize - 1)
        GDI.DrawEllipse(iPen, New Rectangle(0, 0, ImageSize - 1, ImageSize - 1))
        MovingImage = False
        LeftMouseToPaste = True
    End Sub

    Public Sub Restart()
        frmCommand.Hide()
        frmStatus.Hide()
        frmGrid.Hide()
        frmStartup.Show()
    End Sub

    Public Sub ActivateForms()
        frmGrid.Activate()
        frmStatus.Activate()
        WasActivated = True
        frmCommand.Activate()
        Application.DoEvents()
    End Sub

End Module
