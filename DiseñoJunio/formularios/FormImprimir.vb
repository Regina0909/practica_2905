Public Class FormImprimir

    Private dFactura As New FacturaDao
    Private Sub FormImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtTotal_TextChanged(sender As Object, e As EventArgs) Handles TxtTotal.TextChanged

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim factura As New FacturaEntidad()
            factura.FechaFactura = DateFactura.Value
            factura.TotalFactura = Decimal.Parse(TxtTotal.Text)

            Dim consultaID As New ConsultaEntidad()
            consultaID.ConsultaID = TxtID.Text
            factura.ConsultaID = consultaID



            If (dFactura.GuardarRegistro(factura) = True) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Clinica")
            End If
        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try

    End Sub
End Class