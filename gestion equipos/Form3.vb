Imports System
Imports System.IO
Imports System.Collections
Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox12.Text = DateTime.Now.ToString("dd/MM/yyyy")
        ComboBox4.SelectedIndex = 3
        Button3.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Form1
        Dim Codigo As String = TextBox1.Text
        a.Show()
        Me.Finalize()
        If Codigo <> "" Then
            If Directory.Exists(directorio_dir & Codigo) Then
                MsgBox("Se borraran los archivos añadidos")
                My.Computer.FileSystem.DeleteDirectory(directorio_dir & Codigo, FileIO.DeleteDirectoryOption.DeleteAllContents)

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'boton de insertado

        Dim Codigo As String = TextBox1.Text
        Dim Denominacion As String = TextBox2.Text
        Dim Marca As String = TextBox3.Text
        Dim Modelo As String = TextBox4.Text
        Dim Estado As String = ComboBox4.Text
        Dim Especificacion As String = TextBox8.Text
        Dim Serie As String = TextBox5.Text
        Dim software As String = TextBox7.Text
        Dim mantenimiento_calibracion As String = CheckedListBox1.GetItemChecked(1)
        Dim mantenimiento As String = CheckedListBox1.GetItemChecked(0)
        Dim tipo As String = ComboBox2.Text
        Dim ubicacion As String = TextBox9.Text
        Dim caracteristicas As String = TextBox8.Text
        Dim observaciones As String = TextBox10.Text
        Dim fecha_alta As String = TextBox12.Text
        Dim responsable As String = TextBox13.Text
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Equipos(Id_equipo,DENOMINACIÓN,marca,modelo,estado,EXPECIFICACIÓN,serie,SOTFWARE,mantenimiento_CALIBARACION,mantenimiento,UBICACIÓN,caracteristicas,observaciones,fecha_alta,TIPO,RESPONSABLE) values ('" & Codigo & "','" & Denominacion & "','" & Marca & "','" & Modelo & "','" & Estado & "','" & Especificacion & "','" & Serie & "','" & software & "'," & mantenimiento_calibracion & "," & mantenimiento & ",'" & ubicacion & "','" & caracteristicas & "','" & observaciones & "','" & fecha_alta & "','" & tipo & "','" & responsable & "')"

        Try
            dr = cmd.ExecuteReader()
            dr.Read()
            MsgBox("Inserción realizada con exito del Equipo :" & Codigo & "'")

            My.Computer.FileSystem.CreateDirectory(directorio_dir & Codigo)

            Dim a As New Form1
            a.Show()
            Me.Finalize()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If filename <> "" Then
            If Directory.Exists(directorio_dir & Codigo) Then
                If directorio <> "" Then



                    Try
                        My.Computer.FileSystem.CopyFile(directorio, directorio_dir & Codigo & "\" & filename)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                Else
                    My.Computer.FileSystem.CreateDirectory(directorio_dir & Codigo)

                    Try
                        My.Computer.FileSystem.CopyFile(directorio, directorio_dir & Codigo & "\" & filename)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                End If
            End If
        End If

        filename = ""
        directorio = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "I" Then
            TextBox1.Text = genera_codigo("I")
        ElseIf ComboBox1.Text = "A" Then
            TextBox1.Text = genera_codigo("A")
        ElseIf ComboBox1.Text = "B" Then
            TextBox1.Text = genera_codigo("B")
        ElseIf ComboBox1.Text = "E" Then
            TextBox1.Text = genera_codigo("E")
        ElseIf ComboBox1.Text = "T" Then
            TextBox1.Text = genera_codigo("T")
        ElseIf ComboBox1.Text = "P" Then
            TextBox1.Text = genera_codigo("P")
        Else
            TextBox1.Text = ""
        End If

        If ComboBox1.Text = "" Then

            TextBox1.Text = ""
            Button3.Enabled = False

        Else
            If TextBox1.Text <> "" Then
                Button3.Enabled = True
            Else
                Button3.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim dlg As New OpenFileDialog()
        dlg.FileName = "" ' Default file name
        dlg.DefaultExt = "" ' Default file extension


        Dim result? As Boolean = dlg.ShowDialog()
        Dim Codigo As String = TextBox1.Text
        If result = True Then
            filename = Path.GetFileName(dlg.FileName)
            directorio = dlg.FileName
            Label17.Text = filename


        End If
    End Sub

End Class