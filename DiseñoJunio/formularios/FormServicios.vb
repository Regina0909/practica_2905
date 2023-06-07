Imports System.Data.SqlClient

Public Class FormServicios
    Private dServicio As New ServicioDao

    'QUE SE LLENEN LOS CAMPOS AL SELECCIONAR FILA'
    Sub MostrarRegistros()
        Try
            DGVservicio.DataSource = dServicio.MostrarRegistros().Tables(0)
            DGVservicio.Refresh()
            GBservicio.Text = "Registros Guardados: " & DGVservicio.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim servicio As New ServicioEntidad
            servicio.NombreServicio = TxtNombre.Text
            servicio.CostoServicio = Decimal.Parse(TxtCosto.Text)

            servicio.Deleted = False

            If dServicio.GuardarRegistro(servicio) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Clinica")
            End If

        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")

        End Try


        MostrarRegistros()
    End Sub

    Private Sub FormServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarRegistros()

    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click

        If DGVservicio.SelectedRows.Count > 0 Then
            Dim servicioID As Integer = CInt(DGVservicio.SelectedRows(0).Cells("servicioID").Value)

            Dim servicio As New ServicioEntidad()
            servicio.ServicioID = servicioID
            servicio.NombreServicio = TxtNombre.Text
            servicio.CostoServicio = Decimal.Parse(TxtCosto.Text)

            servicio.Deleted = False

            Try
                Dim resp = dServicio.EditarRegistro(servicio)
                If (resp) Then
                    MsgBox("Registro editado satisfactoriamente", MsgBoxStyle.Information, "Clinica")
                Else
                    MsgBox("No se pudo editar el registro.", MsgBoxStyle.Exclamation, "Clinica")
                End If
            Catch ex As Exception
                MsgBox("Error al editar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
            End Try
        Else
            MsgBox("No se ha seleccionado ningún registro para editar.", MsgBoxStyle.Exclamation, "Clinica")
        End If

        MostrarRegistros()

    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim selectedRow As DataGridViewRow = DGVservicio.SelectedRows(0)
            Dim servicioID As Integer = CInt(selectedRow.Cells("servicioID").Value)

            If dServicio.EliminarRegistro(servicioID) Then
                MsgBox("Registro eliminado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo eliminar el registro.", MsgBoxStyle.Exclamation, "Clinica")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try

        MostrarRegistros()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        TxtNombre.Clear()
        TxtCosto.Clear()
        'BtnEditar.Enabled = False
        'BtnEliminar.Enabled = False
        'BtnGuardar.Enabled = True
        TxtNombre.Focus()
        TxtCosto.Focus()

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Dim nombreServicio As String = TxtBuscar.Text.Trim()

        If String.IsNullOrEmpty(nombreServicio) Then
            MostrarRegistros() ' Mostrar todos los registros si no se ingresó un nombre de usuario
        Else
            FiltrarRegistrosPorNombreServicio(nombreServicio)
        End If
    End Sub

    Private Sub FiltrarRegistrosPorNombreServicio(nombreServicio As String)
        Try
            Dim ds As DataSet = dServicio.MostrarRegistros()
            Dim dt As DataTable = ds.Tables(0)

            Dim dv As New DataView(dt)
            dv.RowFilter = $"nombreServicio LIKE '%{nombreServicio}%'"

            DGVservicio.DataSource = dv
            DGVservicio.Refresh()

            GBservicio.Text = "Registros Guardados: " & DGVservicio.Rows.Count
        Catch ex As Exception
            MsgBox("Error al buscar registros: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub DGVservicio_SelectionChanged(sender As Object, e As EventArgs) Handles DGVservicio.SelectionChanged



        If DGVservicio.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DGVservicio.SelectedRows(0)

            TxtNombre.Text = row.Cells("nombreServicio").Value.ToString()




            If TypeOf row.Cells("costoServicio").Value Is Decimal Then
                Dim costoServicio As Decimal = Convert.ToInt32(row.Cells("costoServicio").Value)
                TxtCosto.Text = costoServicio

                BtnGuardar.Enabled = False
            End If

        End If

    End Sub

    Private Sub DGVservicio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVservicio.CellContentClick

    End Sub
End Class