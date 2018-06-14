Imports System
Imports System.IO
Imports System.Collections
Public Class Añadir_mantenimiento_Form3
    Private Sub Añadir_mantenimiento_Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox24.Text = DateTime.Now.ToString("dd/MM/yyyy")
        If ComboBox2.Text = "BAJA" Then

            TextBox14.Enabled = True
        Else
            TextBox14.Enabled = False
            TextBox14.Text = TextBox24.Text
        End If

        Dim Codigo As String
        Dim Denominacion As String
        Dim Marca As String
        Dim Estado As String
        Dim Especificacion As String
        Dim Serie As String
        Dim software As String
        Dim mantenimiento_calibracion As String
        Dim mantenimiento As String
        Dim ubicacion As String
        Dim caracteristicas As String
        Dim observaciones As String
        Dim fecha_alta As String
        Dim fecha_baja As String
        Dim Modelo As String

        Dim estado_int As Integer

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT * FROM Equipos WHERE Id_Equipo= '" & selecionada_equipos & "'"

        dr = cmd.ExecuteReader()
        dr.Read()

        Codigo = selecionada_equipos
        Denominacion = dr(1).ToString
        Marca = dr(2).ToString
        Modelo = dr(3).ToString
        Estado = dr(4).ToString
        Especificacion = dr(5).ToString
        Serie = dr(6).ToString
        software = dr(7).ToString
        mantenimiento_calibracion = dr(8).ToString
        mantenimiento = dr(9).ToString
        ubicacion = dr(10).ToString
        caracteristicas = dr(11).ToString
        observaciones = dr(12).ToString
        fecha_alta = dr(13).ToString
        fecha_baja = dr(14).ToString

        ComboBox2.SelectedIndex = 3

        If Estado = "BAJA" Then

            TextBox11.Enabled = True
            TextBox11.Text = fecha_baja

        End If
        CheckedListBox1.SetItemChecked(1, mantenimiento_calibracion)
        CheckedListBox1.SetItemChecked(0, mantenimiento)
        If Estado = "BAJA" Then
            estado_int = 0
            TextBox11.Enabled = True
            TextBox11.Text = fecha_baja

        ElseIf Estado = "FUERA DE SERVIVIO" Then
            estado_int = 1
        ElseIf Estado = "LIMITACION DE USO" Then
            estado_int = 2
        ElseIf Estado = "OK" Then
            estado_int = 3
        Else
            estado_int = 4
        End If

        TextBox1.Text = Codigo
        TextBox2.Text = Denominacion
        TextBox3.Text = Marca
        TextBox4.Text = Modelo
        TextBox11.Text = Estado
        TextBox6.Text = Especificacion
        TextBox5.Text = Serie
        TextBox7.Text = software
        TextBox9.Text = ubicacion
        TextBox8.Text = caracteristicas
        TextBox10.Text = observaciones
        TextBox13.Text = fecha_alta
        ComboBox2.SelectedIndex = estado_int
        TextBox16.Text = dr(15).ToString
        TextBox18.Text = dr(16).ToString
        If Estado = "BAJA" Then

            TextBox12.Enabled = True
            TextBox12.Text = fecha_baja
        Else
            TextBox12.Enabled = False
        End If
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT tareas.id_equipo, tareas.tipo, tareas.id_tipo FROM tareas WHERE id_equipo='" & selecionada_equipos & "'"

        dr1 = cmd1.ExecuteReader()

        Me.ComboBox3.Items.Add("")


        While dr1.Read()
            Me.ComboBox3.Items.Add(dr1.GetValue(2))
        End While

        If marcada_tarea Then


            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr2 As OleDb.OleDbDataReader

            cmd2.Connection = con
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT * FROM tareas WHERE id_equipo='" & selecionada_equipos & "' and id_tipo= " & selecionada_tarea

            dr2 = cmd2.ExecuteReader()
            dr2.Read()


            Denominacion = dr2(1).ToString
            TextBox25.Text = dr2(2).ToString
            TextBox24.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox17.Text = dr2(4).ToString


            Dim i As Integer = 0
            Dim marcaa As Integer = 0



            For i = 0 To (CStr(ComboBox3.Items.Count) - 1)

                ComboBox3.SelectedIndex = i

                If ComboBox3.Text = selecionada_tarea And marcaa = 0 Then

                    ComboBox3.SelectedIndex = i
                    marcaa = i
                End If
            Next
            ComboBox3.SelectedIndex = marcaa



        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Codigo_mantenimiento As String = TextBox26.Text
        Dim operacion As String = TextBox25.Text
        Dim fecha_de_mantenimiento As String = TextBox24.Text
        Dim Estado As String = ComboBox2.Text
        Dim obserbaciones As String = TextBox17.Text
        Dim t_M_Preventivo As String = CheckedListBox2.GetItemChecked(0)
        Dim t_M_correctivo As String = CheckedListBox2.GetItemChecked(1)
        Dim t_calibracion As String = CheckedListBox2.GetItemChecked(2)

        Dim fecha_baja As String = TextBox14.Text
        Dim tarea As String = ComboBox3.Text

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        If directorio <> "" Then



        End If
        If selecionada_tarea = "" Then
            If directorio = "" Then

                cmd.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " ')"
            Else
                cmd.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones,Certificado) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & "' ,'" & filename & "')"

            End If

        Else
            If directorio = "" Then


                cmd.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones,tipo_tarea) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " '," & selecionada_tarea & ")"

            Else
                cmd.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones,tipo_tarea,Certificado) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " '," & selecionada_tarea & "','" & filename & "')"

            End If


        End If



        Try
            dr = cmd.ExecuteReader()
            dr.Read()
            MsgBox("Inserción realizada con exito ")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader
        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text




        If Estado = "BAJA" Then
            cmd1.CommandText = "update Equipos set estado='" & Estado & "', fecha_baja='" & fecha_baja & "' where id_Equipo='" & selecionada_equipos & "'"
        Else
            cmd1.CommandText = "update Equipos set estado='" & Estado & "' where id_Equipo='" & selecionada_equipos & "'"
        End If

        Try
            dr1 = cmd1.ExecuteReader()
            dr1.Read()

            Dim a As New Form2
            a.Show()
            Me.Finalize()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        If Directory.Exists(directorio_dir & selecionada_equipos) Then
            If directorio <> "" Then



                Try
                    My.Computer.FileSystem.CopyFile(directorio, directorio_dir & selecionada_equipos & "\" & filename)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Else
                My.Computer.FileSystem.CreateDirectory(directorio_dir & selecionada_equipos)

                Try
                    My.Computer.FileSystem.CopyFile(directorio, directorio_dir & selecionada_equipos & "\" & filename)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If
        End If
        directorio = ""
        filename = ""



    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "BAJA" Then

            TextBox14.Enabled = True
            TextBox14.Text = TextBox24.Text
        Else
            TextBox14.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Form2
        a.Show()
        Me.Finalize()
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        If ComboBox3.Text = "" Then
            TextBox25.Text = ""
            CheckedListBox2.SetItemChecked(0, False)
            CheckedListBox2.SetItemChecked(2, False)
            TextBox17.Text = ""

        Else


            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr2 As OleDb.OleDbDataReader


            cmd2.Connection = con
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT * FROM tareas WHERE id_equipo='" & selecionada_equipos & "' and id_tipo=" & ComboBox3.Text

            dr2 = cmd2.ExecuteReader()
            dr2.Read()

            TextBox25.Text = dr2(2).ToString
            CheckedListBox2.SetItemChecked(0, dr2(5).ToString)
            CheckedListBox2.SetItemChecked(2, dr2(6).ToString)
            TextBox17.Text = dr2(4).ToString

        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dlg As New OpenFileDialog()
        dlg.FileName = "" ' Default file name
        dlg.DefaultExt = "" ' Default file extension


        Dim result? As Boolean = dlg.ShowDialog()
        Dim Codigo As String = TextBox1.Text
        If result = True Then
            filename = Path.GetFileName(dlg.FileName)
            directorio = dlg.FileName
            TextBox15.Text = filename


        End If
    End Sub



    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox15.Text <> "" Then

            TextBox15.Text = ""
        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

        Dim result As Integer = DateTime.Compare(Convert.ToDateTime(TextBox12.Text), Convert.ToDateTime(TextBox13.Text))


        If result >= 0 Then
        Else
            TextBox13.Text = ""
        End If
    End Sub


End Class