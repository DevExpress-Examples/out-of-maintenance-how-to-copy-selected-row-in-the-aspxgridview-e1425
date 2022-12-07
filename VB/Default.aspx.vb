Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data

Namespace WebApplication10
	Partial Public Class _Default
		Inherits System.Web.UI.Page

		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			If Session("InitialData") Is Nothing Then
				Dim dt As New DataTable()
				dt.Columns.Add("ID", GetType(Integer))
				dt.Columns.Add("Data", GetType(String))
				For i As Integer = 0 To 4
					dt.Rows.Add(New Object() { i, "Data_" & i.ToString() })
					Session("InitialData") = dt
				Next i

			End If

			If Session("TargetData") Is Nothing Then
				Dim dt1 As New DataTable()
				dt1.Columns.Add("ID", GetType(Integer))
				dt1.Columns.Add("Data", GetType(String))
				Dim keys(0) As DataColumn
				keys(0) = dt1.Columns("ID")
				dt1.PrimaryKey = keys


				Session("TargetData") = dt1

			End If
			ASPxGridView1.DataSource = TryCast(Session("InitialData"), DataTable)
			ASPxGridView1.DataBind()

			ASPxGridView2.DataSource = TryCast(Session("TargetData"), DataTable)
			ASPxGridView2.DataBind()
		End Sub

		Protected Sub AddRow(ByVal row As DataRow)

			Dim rw As DataRow = (TryCast(Session("TargetData"), DataTable)).NewRow()
			rw(0) = row(0)
			rw(1) = row(1)
                                                Dim dt As DataTable = TryCast(Session("TargetData"), DataTable)
			dt.Rows.Add(rw)
                                                Session("TargetData") = dt
			ASPxGridView2.DataBind()
		End Sub
		Protected Sub DeleteRow(ByVal row As DataRow)

			Dim currentDT As DataTable = TryCast(Session("TargetData"), DataTable)
			Dim rw As DataRow = currentDT.Rows.Find(row(0))
			For i As Integer = 0 To currentDT.Rows.Count - 1
				If Convert.ToInt32(currentDT.Rows(i)(0)) = Convert.ToInt32(row(0)) Then
					currentDT.Rows(i).Delete()
					Exit For
				End If
			Next i
			Session("TargetData") = currentDT

			ASPxGridView2.DataBind()

		End Sub

		Protected Sub ASPxCallbackPanel1_Callback(ByVal source As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
			Dim pars() As String = e.Parameter.Split(";"c)
			Dim index As Integer = Convert.ToInt32(pars(0))
			If pars(1) = "y" Then

				AddRow(ASPxGridView1.GetDataRow(index))
			End If
			If pars(1) = "n" Then

				DeleteRow(ASPxGridView1.GetDataRow(index))
			End If

		End Sub
	End Class
End Namespace

