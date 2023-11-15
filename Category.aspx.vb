Public Class Category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("SearchString") <> "" Then
            SqlDSProductList.SelectCommand = "Select * From Product Where ProductName Like '%" & Request.QueryString("SearchString") & "%'"
            SqlDSProductList.DataBind()
            ' handle the lblProductList

        Else
            If Request.QueryString("MainCategoryID") <> "" Then
                lblMainCategoryName.Text = Request.QueryString("MainCategoryName")
                sqlDSSubCategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCategoryID"))
                If Request.QueryString("SubCategoryID") <> "" Then
                    lblProductList.Text = "Product List for: " & Request.QueryString("SubCategoryName")
                    SqlDSProductList.SelectCommand = "Select * From Product Where SubCategoryID = " & Int(Request.QueryString("SubCategoryID"))
                    SqlDSProductList.DataBind()
                End If
            End If
        End If
    End Sub

End Class