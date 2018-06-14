Imports System
Imports System.IO
Imports System.Collections
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        selecionada_tarea = ""
        selecionada_mantenimientto = ""
        marcada_tarea = False
        marcada_mantenimiento = False


        Dim Codigo As String = selecionada_equipos
        Dim Denominacion As String
        Dim Marca As String
        Dim Modelo As String
        Dim Estado As String
        Dim Especificacion As String
        Dim Serie As String
        Dim software As String
        Dim mantenimiento_calibracion As Boolean
        Dim mantenimiento As Boolean
        Dim ubicacion As String
        Dim caracteristicas As String
        Dim observaciones As String
        Dim fecha_alta As String
        Dim fecha_baja As String

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        marcada_mantenimiento = False
        marcada_tarea = False
        selecionada_tarea = ""
        selecionada_mantenimientto = ""
        Label1.Text = "Ultimos mantenimientos"
        Button2.Text = "Tareas de mantenimiento"
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT * FROM Equipos WHERE Id_Equipo= '" & Codigo & "'"
        dr = cmd.ExecuteReader()
        dr.Read()
        'insercion de datos en sus variables
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

        CheckedListBox1.SetItemChecked(1, mantenimiento_calibracion)
        CheckedListBox1.SetItemChecked(0, mantenimiento)
        TextBox1.Text = Codigo
        TextBox2.Text = Denominacion
        TextBox3.Text = Marca
        TextBox4.Text = Modelo
        ComboBox4.SelectedIndex = ComboBox4.FindString(Estado)
        TextBox6.Text = Especificacion
        TextBox5.Text = Serie
        TextBox7.Text = software
        TextBox9.Text = ubicacion
        TextBox8.Text = caracteristicas
        TextBox10.Text = observaciones
        TextBox12.Text = fecha_alta
        TextBox13.Text = dr(15).ToString
        ComboBox2.SelectedIndex = ComboBox2.FindString(dr(16).ToString)

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM mantenimiento  WHERE id_equipo= '" & selecionada_equipos & "'"
        Dim adp As New OleDb.OleDbDataAdapter(sql, con)
        ds.Tables.Add("mantenimiento")
        adp.Fill(ds.Tables("mantenimiento"))

        Me.DataGridView1.DataSource = ds.Tables("mantenimiento")
        Dim folder As New DirectoryInfo(directorio_dir & selecionada_equipos)


        If Directory.Exists(directorio_dir & selecionada_equipos) Then

            ComboBox1.Items.Clear()
            For Each fi In folder.GetFiles()

                ComboBox1.Items.Add(fi.Name)
            Next
        End If
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "BAJA" Then

            TextBox11.Enabled = True
            TextBox11.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Else
            TextBox11.Enabled = False
            TextBox11.Text = ""
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim i As Integer = DataGridView1.CurrentRow.Index

        If Label1.Text = "Tareas de mantenimiento" Then
            If RadioButton1.Checked = True Then


                selecionada_tarea = DataGridView1.Item(0, i).Value
                selecionada_mantenimientto = ""
                marcada_mantenimiento = False
                marcada_tarea = True
                Dim a As New Añadir_mantenimiento_Form3
                a.Show()
                Me.Finalize()

            ElseIf RadioButton2.Checked = True Then

                selecionada_tarea = DataGridView1.Item(0, i).Value
                selecionada_mantenimientto = ""
                marcada_mantenimiento = False
                marcada_tarea = False
                Dim resultado As String = ""
                resultado = MsgBox("¿Estas seguro que quieres elimirar la tarea " & selecionada_tarea & " ? ", MsgBoxStyle.OkCancel)

                If resultado = vbOK Then


                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader

                    cmd.Connection = con
                    cmd.CommandType = CommandType.Text

                    cmd.CommandText = "delete from tareas where Id_tipo=" & selecionada_tarea



                    Try
                        dr = cmd.ExecuteReader()
                        dr.Read()


                        MsgBox("Eliminacion realizada con exito de la tarea '" & selecionada_tarea & "'")


                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try


                End If

                Dim a As New Form2
                a.Show()
                Me.Finalize()

            End If
        Else
            marcada_mantenimiento = True
            marcada_tarea = False
            selecionada_tarea = ""
            selecionada_mantenimientto = DataGridView1.Item(0, i).Value
            Dim a As New Form4
            a.Show()
            Me.Finalize()
        End If


    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To CheckedListBox1.Items.Count - 1
            If (CheckedListBox1.GetItemChecked(i)) Then
                MessageBox.Show(CheckedListBox1.GetItemText(i))
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Label1.Text = "Tareas de mantenimiento" Then
            Label1.Text = "Ultimos mantenimientos"
            Button2.Text = "Tareas de mantenimiento"
            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM mantenimiento  WHERE id_equipo= '" & selecionada_equipos & "'"
            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("mantenimiento")
            adp.Fill(ds.Tables("mantenimiento"))
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False

            Me.DataGridView1.DataSource = ds.Tables("mantenimiento")
        Else
            Label1.Text = "Tareas de mantenimiento"
            Button2.Text = "Ultimos mantenimientos"
            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM tareas  WHERE id_equipo= '" & selecionada_equipos & "'"
            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("tareas")
            adp.Fill(ds.Tables("tareas"))
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True



            Me.DataGridView1.DataSource = ds.Tables("tareas")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a As New Form1
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a As New tareas_de_mantenimiento
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        marcada_tarea = False
        Dim a As New Añadir_mantenimiento_Form3
        a.Show()
        Me.Finalize()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Codigo As String = selecionada_equipos
        Dim Denominacion As String = TextBox2.Text
        Dim Marca As String = TextBox3.Text
        Dim Modelo As String = TextBox4.Text
        Dim Estado As String = ComboBox4.Text
        Dim Especificacion As String = TextBox6.Text
        Dim Serie As String = TextBox5.Text
        Dim software As String = TextBox7.Text
        Dim mantenimiento_calibracion As String = CheckedListBox1.GetItemChecked(1)
        Dim mantenimiento As String = CheckedListBox1.GetItemChecked(0)
        Dim ubicacion As String = TextBox9.Text
        Dim caracteristicas As String = TextBox8.Text
        Dim observaciones As String = TextBox10.Text
        Dim fecha_alta As String = TextBox12.Text
        Dim fecha_baja As String = TextBox11.Text
        Dim tipo As String = ComboBox2.Text
        Dim responsable As String = TextBox13.Text


        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update Equipos set DENOMINACIÓN='" & Denominacion & "', MARCA='" & Marca & "', MODELO='" & Modelo & "', ESTADO='" & Estado & "',EXPECIFICACIÓN='" & Especificacion & "', serie='" & Serie & "', SOTFWARE='" & software & "', mantenimiento_CALIBARACION=" & mantenimiento_calibracion & ", mantenimiento=" & mantenimiento & ",UBICACIÓN='" & ubicacion & "', caracteristicas='" & caracteristicas & "', observaciones='" & observaciones & "', fecha_alta='" & fecha_alta & "', TIPO='" & tipo & "', FECHA_BAJA='" & fecha_baja & "', RESPONSABLE='" & responsable & "' where Id_Equipo='" & selecionada_equipos & "'"





        Try
            dr = cmd.ExecuteReader()
            dr.Read()
            MsgBox("Modificacion realizada con exito del Equipo " & Denominacion)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim resultado As String = ""
        resultado = MsgBox("¿Estas seguro que quieres borrar el equipo? ", MsgBoxStyle.OkCancel)

        If resultado = vbOK Then


            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader

            cmd.Connection = con
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "delete from Equipos where Id_equipo='" & selecionada_equipos & "'"


            Dim cmd1 As New OleDb.OleDbCommand
            Dim dr1 As OleDb.OleDbDataReader

            cmd1.Connection = con
            cmd1.CommandType = CommandType.Text
            cmd1.CommandText = "delete from tareas where id_equipo='" & selecionada_equipos & "'"

            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr2 As OleDb.OleDbDataReader

            cmd2.Connection = con
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "delete from mantenimiento where id_equipo='" & selecionada_equipos & "'"


            Try
                dr = cmd.ExecuteReader()
                dr.Read()
                dr1 = cmd1.ExecuteReader()
                dr1.Read()
                dr2 = cmd2.ExecuteReader()
                dr2.Read()

                MsgBox("Eliminacion realizada con exito del Equipo '" & selecionada_equipos & "'")
                Dim a As New Form1
                a.Show()
                Me.Finalize()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            If Directory.Exists(directorio_dir & selecionada_equipos) Then
                MsgBox("Se borraran los archivos añadidos")
                My.Computer.FileSystem.DeleteDirectory(directorio_dir & selecionada_equipos, FileIO.DeleteDirectoryOption.DeleteAllContents)

            End If

        End If
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim dlg As New OpenFileDialog()
        dlg.FileName = "" ' Default file name
        dlg.DefaultExt = "" ' Default file extension


        Dim result? As Boolean = dlg.ShowDialog()
        Dim Codigo As String = TextBox1.Text
        If result = True Then
            Dim filename As String = Path.GetFileName(dlg.FileName)
            Dim directorio As String = dlg.FileName
            If Directory.Exists(directorio_dir & Codigo) Then

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

        Dim folder As New DirectoryInfo(directorio_dir & selecionada_equipos)
        Dim fila As Integer = 0

        If Directory.Exists(directorio_dir & selecionada_equipos) Then

            ComboBox1.Items.Clear()

            For Each fi In folder.GetFiles()

                ComboBox1.Items.Add(fi.Name)
            Next




        End If
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If ComboBox1.Text <> "" Then
            Dim s As String = directorio_dir & selecionada_equipos & "\" & ComboBox1.Text
            Dim p As New Process()
            p.StartInfo.FileName = s
            Try
                p.Start()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else

        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ComboBox1.Text <> "" Then


            My.Computer.FileSystem.DeleteFile(directorio_dir & selecionada_equipos & "\" & ComboBox1.Text)
            Dim folder As New DirectoryInfo(directorio_dir & selecionada_equipos)
            ComboBox1.Items.Clear()

            If Directory.Exists(directorio_dir & selecionada_equipos) Then


                For Each fi In folder.GetFiles()

                    ComboBox1.Items.Add(fi.Name)
                Next
            End If
            ComboBox1.Text = ""
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class