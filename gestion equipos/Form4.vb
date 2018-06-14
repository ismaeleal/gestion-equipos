Imports System
Imports System.IO
Imports System.Collections
Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT tareas.id_equipo, tareas.tipo, tareas.id_tipo FROM tareas WHERE id_equipo='" & selecionada_equipos & "'"

        dr1 = cmd1.ExecuteReader()

        Me.ComboBox1.Items.Add("")


        While dr1.Read()
            Me.ComboBox1.Items.Add(dr1.GetValue(2))
        End While

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT * FROM mantenimiento WHERE Id_mantenimineto= " & selecionada_mantenimientto

        dr = cmd.ExecuteReader()
        dr.Read()

        TextBox26.Text = selecionada_equipos
        TextBox25.Text = dr(2).ToString
        TextBox24.Text = dr(3).ToString
        CheckedListBox2.SetItemChecked(0, dr(4).ToString)
        CheckedListBox2.SetItemChecked(1, dr(5).ToString)
        CheckedListBox2.SetItemChecked(2, dr(6).ToString)
        ComboBox1.SelectedIndex=ComboBox1.FindString(dr(9).ToString)
        TextBox17.Text = dr(8).ToString
        TextBox15.Text = dr(10).ToString
        ComboBox2.SelectedIndex = ComboBox2.FindString(dr(7).ToString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Form2
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim s As String = directorio_dir & selecionada_equipos & "\" & TextBox15.Text
        If TextBox15.Text <> "" Then
            If File.Exists(s) Then
                Dim p As New Process()
                p.StartInfo.FileName = s
                p.Start()
            Else
                Dim cmd As New OleDb.OleDbCommand
                Dim dr As OleDb.OleDbDataReader

                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "update mantenimiento set Certificado='' where Id_mantenimineto=" & selecionada_mantenimientto
                dr = cmd.ExecuteReader()
                dr.Read()

                TextBox15.Text = ""
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox15.Text = "" Then
            Dim dlg As New OpenFileDialog()
            dlg.FileName = "" ' Default file name
            dlg.DefaultExt = "" ' Default file extension


            Dim result? As Boolean = dlg.ShowDialog()
            Dim Codigo As String = selecionada_equipos
            If result = True Then
                Dim filename As String = Path.GetFileName(dlg.FileName)
                Dim directorio As String = dlg.FileName
                If Directory.Exists(directorio_dir & Codigo) Then
                Else
                    My.Computer.FileSystem.CreateDirectory(directorio_dir & Codigo)
                End If

                Dim s As String = directorio_dir & selecionada_equipos & "\" & filename
                If TextBox15.Text = "" Then
                    If File.Exists(s) Then
                        Dim cmd As New OleDb.OleDbCommand
                        Dim dr As OleDb.OleDbDataReader

                        cmd.Connection = con
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "update mantenimiento set Certificado='" & filename & "' where Id_mantenimineto=" & selecionada_mantenimientto
                        dr = cmd.ExecuteReader()
                        dr.Read()

                        TextBox15.Text = filename
                    Else

                        Try
                            My.Computer.FileSystem.CopyFile(directorio, directorio_dir & Codigo & "\" & filename)
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        Dim cmd As New OleDb.OleDbCommand
                        Dim dr As OleDb.OleDbDataReader

                        cmd.Connection = con
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "update mantenimiento set Certificado='" & filename & "' where Id_mantenimineto=" & selecionada_mantenimientto
                        dr = cmd.ExecuteReader()
                        dr.Read()

                        TextBox15.Text = filename
                    End If
                End If
            End If
        Else
            MsgBox("Ya existe un certificado. Eliminalo si deasea añadir uno nuevo")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        If TextBox15.Text <> "" Then
            Dim s As String = directorio_dir & selecionada_equipos & "\" & TextBox15.Text
            If File.Exists(s) Then
                My.Computer.FileSystem.DeleteFile(directorio_dir & selecionada_equipos & "\" & TextBox15.Text)
                Dim folder As New DirectoryInfo(directorio_dir & selecionada_equipos)
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "update mantenimiento set Certificado='' where Id_mantenimineto=" & selecionada_mantenimientto
                dr = cmd.ExecuteReader()
                dr.Read()

                TextBox15.Text = ""
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click '' eliminar
        Dim resultado As String = ""
        resultado = MsgBox("¿Estas seguro que quieres borrar el Mantenimiento ? ", MsgBoxStyle.OkCancel)

        If resultado = vbOK Then


            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader

            cmd.Connection = con
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "delete from mantenimiento where Id_equipo='" & selecionada_mantenimientto



            Try
                dr = cmd.ExecuteReader()
                dr.Read()


                MsgBox("Eliminacion realizada con exito del Equipo '" & selecionada_equipos & "'")
                Dim a As New Form2
                a.Show()
                Me.Finalize()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click '' modificar
        Dim Codigo As String = selecionada_equipos
        Dim tarea As String = ComboBox1.Text
        Dim operacion As String = TextBox25.Text
        Dim fecha_mantenimiento As String = TextBox24.Text
        Dim Estado As String = ComboBox2.Text
        Dim observaciones As String = TextBox17.Text
        Dim Certificacion As String = TextBox15.Text

        Dim mantenimiento_calibracion As String = CheckedListBox2.GetItemChecked(2)
        Dim mantenimiento_corectivo As String = CheckedListBox2.GetItemChecked(1)
        Dim mantenimiento As String = CheckedListBox2.GetItemChecked(0)


        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text

        If tarea = "" Then
            If Certificacion = "" Then


                cmd.CommandText = "update mantenimiento set operacion='" & operacion & "', fecha_mantenimiento='" & fecha_mantenimiento & "', M_Preventivo=" & mantenimiento & ", M_correctivo=" & mantenimiento_corectivo & ",calibracion=" & mantenimiento_calibracion & ", observaciones='" & observaciones & "', estado='" & Estado & "'  WHERE Id_mantenimineto= " & selecionada_mantenimientto

            Else
                cmd.CommandText = "update mantenimiento set operacion='" & operacion & "', fecha_mantenimiento='" & fecha_mantenimiento & "', M_Preventivo=" & mantenimiento & ", M_correctivo=" & mantenimiento_corectivo & ",calibracion=" & mantenimiento_calibracion & ", observaciones='" & observaciones & "', Certificado ='" & Certificacion & "', estado='" & Estado & "'  WHERE Id_mantenimineto= " & selecionada_mantenimientto

            End If

        Else
            If Certificacion = "" Then

                cmd.CommandText = "update mantenimiento set operacion='" & operacion & "', fecha_mantenimiento='" & fecha_mantenimiento & "', M_Preventivo=" & mantenimiento & ", M_correctivo=" & mantenimiento_corectivo & ",calibracion=" & mantenimiento_calibracion & ", observaciones='" & observaciones & "', tipo_tarea='" & tarea & "', estado='" & Estado & "' WHERE Id_mantenimineto= " & selecionada_mantenimientto

            Else
                cmd.CommandText = "update mantenimiento set operacion='" & operacion & "', fecha_mantenimiento='" & fecha_mantenimiento & "', M_Preventivo=" & mantenimiento & ", M_correctivo=" & mantenimiento_corectivo & ",calibracion=" & mantenimiento_calibracion & ", observaciones='" & observaciones & "', Certificado ='" & Certificacion & "', tipo_tarea='" & tarea & "', estado='" & Estado & "' WHERE Id_mantenimineto= " & selecionada_mantenimientto


            End If


        End If


        Try
            dr = cmd.ExecuteReader()
            dr.Read()
            MsgBox("Modificacion realizada con exito del Equipo ")
            Dim a As New Form2
            a.Show()
            Me.Finalize()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class