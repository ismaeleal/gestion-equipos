Imports System
Imports System.IO
Imports System.Collections
Imports System.String
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'inicializacion de variables publicas
        selecionada_equipos = ""
        selecionada_tarea = ""
        selecionada_mantenimientto = ""
        marcada_tarea = False
        marcada_mantenimiento = False





        If con.State = ConnectionState.Closed Then

            conectarse()
        End If

        If con.State = ConnectionState.Open Then
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True
            TextBox1.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Label5.Text = directorio_base_datos
            'proceso de aviso 
            avisos()

            'rellena de data
            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM Equipos;"
            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("Equipos")
            adp.Fill(ds.Tables("Equipos"))

            Me.DataGridView1.DataSource = ds.Tables("Equipos")

            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If (row.Cells(“ESTADO”).Value) & "" = “BAJA” Then
                    row.DefaultCellStyle.BackColor = Color.Red
                ElseIf row.Cells(“ESTADO”).Value & "" = "LIMITACION DE USO" Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next

            Dim cmd1 As New OleDb.OleDbCommand
            Dim dr1 As OleDb.OleDbDataReader


            cmd1.Connection = con
            cmd1.CommandType = CommandType.Text
            cmd1.CommandText = "SELECT Estado,TIPO,UBICACIÓN FROM Equipos"

            dr1 = cmd1.ExecuteReader()

            ComboBox1.Items.Add("")

            ComboBox3.Items.Add("")
            Dim j As Integer = 0

            While dr1.Read()

                If ComboBox1.FindString(dr1.GetValue(0)) = -1 Then
                    ComboBox1.Items.Add(dr1.GetValue(0))
                End If

                If ComboBox3.FindString(dr1.GetValue(2)) = -1 Then
                    ComboBox3.Items.Add(dr1.GetValue(2))
                End If


            End While
        Else
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False



        End If



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        If Label4.Text = "Equipos" Then
            marcada_mantenimiento = False
            marcada_tarea = False
            selecionada_equipos = DataGridView1.Item(0, i).Value
            Dim a As New Form2
            a.Show()
            Me.Finalize()

        ElseIf Label4.Text = "Avisos" Then
            'cuando esta en  avisos 

            marcada_mantenimiento = False
            marcada_tarea = True
            selecionada_equipos = DataGridView1.Item(1, i).Value
            selecionada_tarea = DataGridView1.Item(2, i).Value

            Dim a As New Añadir_mantenimiento_Form3
            a.Show()
            Me.Finalize()

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New Form3
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Button3.Text = "Equipos" Then
            Label4.Text = "Equipos"
            Button3.Text = "Avisos"
            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM Equipos;"
            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("Equipos")
            adp.Fill(ds.Tables("Equipos"))

            Me.DataGridView1.DataSource = ds.Tables("Equipos")

            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If row.Cells(“estado”).Value = “BAJA” Then
                    row.DefaultCellStyle.BackColor = Color.Red
                ElseIf row.Cells(“estado”).Value = “LIMITACION DE USO” Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next

        Else
            Label4.Text = "Avisos"
            Button3.Text = "Equipos"

            Dim ds1 As New DataSet
            Dim sql1 As String = "SELECT * FROM avisos;"
            Dim adp1 As New OleDb.OleDbDataAdapter(sql1, con)
            ds1.Tables.Add("avisos")
            adp1.Fill(ds1.Tables("avisos"))
            Me.DataGridView1.DataSource = ds1.Tables("avisos")

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ds As New DataSet
        Dim codigo As String = TextBox1.Text
        Dim estado As String = ComboBox1.Text
        Dim tipo As String = ComboBox2.Text
        Dim ubicacion As String = ComboBox3.Text
        If Label4.Text = "Equipos" Then


            If codigo <> "" Then
                codigo = " AND (Id_Equipo LIKE '%" & codigo & "%')"
            End If
            If estado <> "" Then
                estado = " And (estado Like '%" & estado & "%')"
            End If
            If tipo <> "" Then
                tipo = "AND (TIPO LIKE '%" & tipo & "%')"
            End If
            If ubicacion <> "" Then
                ubicacion = " AND (UBICACIÓN LIKE '%" & ubicacion & "%')"
            End If


            Dim sql As String = "SELECT * FROM Equipos  WHERE (true " & codigo & estado & tipo & ubicacion & " )"

            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("Equipos")
            adp.Fill(ds.Tables("Equipos"))

            Me.DataGridView1.DataSource = ds.Tables("Equipos")
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                    If row.Cells(“estado”).Value = “BAJA” Then
                        row.DefaultCellStyle.BackColor = Color.Red
                    ElseIf row.Cells(“estado”).Value = “LIMITACION DE USO” Then
                        row.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                Next

        Else
            If codigo = "" Then
                Dim sql As String = "SELECT * FROM avisos"

                Dim adp As New OleDb.OleDbDataAdapter(sql, con)
                ds.Tables.Add("avisos")
                adp.Fill(ds.Tables("avisos"))

                Me.DataGridView1.DataSource = ds.Tables("avisos")

            Else
                Dim sql As String = "SELECT * FROM avisos  WHERE id_equipo LIKE '%" & codigo & "%'"

                Dim adp As New OleDb.OleDbDataAdapter(sql, con)
                ds.Tables.Add("avisos")
                adp.Fill(ds.Tables("avisos"))

                Me.DataGridView1.DataSource = ds.Tables("avisos")
            End If
        End If


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dlg As New OpenFileDialog()
        dlg.FileName = "base_de_datos" ' Default file name
        dlg.DefaultExt = ".mdb" ' Default file extension
        dlg.Filter = "Base de datos|*.mdb"

        Dim result? As Boolean = dlg.ShowDialog()

        If result = True Then
            Dim filename As String = dlg.FileName
            directorio_base_datos = filename
            My.Settings.directorio = directorio_base_datos
            My.Settings.Save()
            directorio_base_datos = ""
            Dim a As New Form1
            a.Show()
            Me.Finalize()

        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs)



        Label4.Text = "Avisos"
        Button3.Text = "Equipos"

        Dim ds1 As New DataSet
        Dim sql1 As String = "SELECT * FROM avisos;"
        Dim adp1 As New OleDb.OleDbDataAdapter(sql1, con)
        ds1.Tables.Add("avisos")
        adp1.Fill(ds1.Tables("avisos"))

        Me.DataGridView1.DataSource = ds1.Tables("avisos")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Label4.Text = "Equipos" Then
            Dim codigo As String = TextBox1.Text
            Dim estado As String = ComboBox1.Text
            Dim tipo As String = ComboBox2.Text
            Dim ubicacion As String = ComboBox3.Text
            If codigo <> "" Then
                codigo = " AND (Id_Equipo LIKE '%" & codigo & "%')"
            End If
            If estado <> "" Then
                estado = " And (estado Like '%" & estado & "%')"
            End If
            If tipo <> "" Then
                tipo = "AND (TIPO LIKE '%" & tipo & "%')"
            End If
            If ubicacion <> "" Then
                ubicacion = " AND (UBICACIÓN LIKE '%" & ubicacion & "%')"
            End If

            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM Equipos  WHERE (true " & codigo & estado & tipo & ubicacion & " )"

            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("Equipos")
            adp.Fill(ds.Tables("Equipos"))



            Me.DataGridView1.DataSource = ds.Tables("Equipos")
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If row.Cells(“estado”).Value = “BAJA” Then
                    row.DefaultCellStyle.BackColor = Color.Red
                ElseIf row.Cells(“estado”).Value = “LIMITACION DE USO” Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next

        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If Label4.Text = "Equipos" Then
            Dim codigo As String = TextBox1.Text
            Dim estado As String = ComboBox1.Text
            Dim tipo As String = ComboBox2.Text
            Dim ubicacion As String = ComboBox3.Text
            If codigo <> "" Then
                codigo = "AND (Id_Equipo LIKE '%" & codigo & "%')"
            End If
            If estado <> "" Then
                estado = " And (estado Like '%" & estado & "%')"
            End If
            If tipo <> "" Then
                tipo = "AND (TIPO LIKE '%" & tipo & "%')"
            End If
            If ubicacion <> "" Then
                ubicacion = " AND (UBICACIÓN LIKE '%" & ubicacion & "%')"
            End If

            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM Equipos  WHERE (true " & codigo & estado & tipo & ubicacion & " )"

            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("Equipos")
            adp.Fill(ds.Tables("Equipos"))



            Me.DataGridView1.DataSource = ds.Tables("Equipos")
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If row.Cells(“estado”).Value = “BAJA” Then
                    row.DefaultCellStyle.BackColor = Color.Red
                ElseIf row.Cells(“estado”).Value = “LIMITACION DE USO” Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If Label4.Text = "Equipos" Then
            Dim codigo As String = TextBox1.Text
            Dim estado As String = ComboBox1.Text
            Dim tipo As String = ComboBox2.Text
            Dim ubicacion As String = ComboBox3.Text
            If codigo <> "" Then
                codigo = " AND (Id_Equipo LIKE '%" & codigo & "%')"
            End If
            If estado <> "" Then
                estado = " And (estado Like '%" & estado & "%')"
            End If
            If tipo <> "" Then
                tipo = "AND (TIPO LIKE '%" & tipo & "%')"
            End If
            If ubicacion <> "" Then
                ubicacion = " AND (UBICACIÓN LIKE '%" & ubicacion & "%')"
            End If

            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM Equipos  WHERE (true " & codigo & estado & tipo & ubicacion & " )"

            Dim adp As New OleDb.OleDbDataAdapter(sql, con)
            ds.Tables.Add("Equipos")
            adp.Fill(ds.Tables("Equipos"))



            Me.DataGridView1.DataSource = ds.Tables("Equipos")
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If row.Cells(“estado”).Value = “BAJA” Then
                    row.DefaultCellStyle.BackColor = Color.Red
                ElseIf row.Cells(“estado”).Value = “LIMITACION DE USO” Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim a As New Form5
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a As New Form6
        a.Show()
        Me.Finalize()
    End Sub
End Class
