Public Class FormRegFactura
    Private dFactura As New FacturaDao

    Private Sub FormRegFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarRegistros()



    End Sub

    Sub MostrarRegistros()
        Dim facturaDao As New FacturaDao
        DGVfacturas.DataSource = facturaDao.MostrarRegistros().Tables(0)
        DGVfacturas.Refresh()
        GroupBox1.Text = "Registros Guardados: " & DGVfacturas.Rows.Count

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim fechaFactura As String = TxtBuscar.Text.Trim()

        If String.IsNullOrEmpty(fechaFactura) Then
            MostrarRegistros()
        Else
            FiltrarRegistrosPorFechaFactura(fechaFactura)
        End If
    End Sub

    Private Sub FiltrarRegistrosPorFechaFactura(fechaFactura As String)
        Try
            Dim ds As DataSet = dFactura.MostrarRegistros()
            Dim dt As DataTable = ds.Tables(0)

            Dim dv As New DataView(dt)
            dv.RowFilter = $"CONVERT(fechaFactura, 'System.String') LIKE '%{fechaFactura}%'"

            DGVfacturas.DataSource = dv
            DGVfacturas.Refresh()

            GroupBox1.Text = "Registros Guardados: " & DGVfacturas.Rows.Count
        Catch ex As Exception
            MsgBox("Error al buscar registros: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try
    End Sub

    Private Sub DGVfacturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVfacturas.CellContentClick

    End Sub
End Class