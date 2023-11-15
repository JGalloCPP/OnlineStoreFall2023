Imports System.Data
Imports System.Data.SqlClient
Public Class ProductDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ProductID") <> "" Then
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
            Dim connProduct As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            Dim strSQL As String = "Select * from Product Where ProductID = '" & Request.QueryString("ProductID") & "'"
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblProductName.Text = drProduct.Item("ProductName")
                lblProductNo.Text = drProduct.Item("ProductID")
                lblProductPrice.Text = drProduct.Item("Price")
            Else

            End If
        End If
    End Sub

End Class