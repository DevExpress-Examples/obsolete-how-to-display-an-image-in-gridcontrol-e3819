Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form



		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim images() As Image = { My.Resources.about, My.Resources.add, My.Resources.apple, My.Resources.arrow_down, My.Resources.arrow_left}
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			tbl.Columns.Add("Image", GetType(Image))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i), images(i Mod images.Length) })
			Next i
			Return tbl
		End Function

		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = CreateTable(20)
			gridView1.Columns("Image").ColumnEdit = New RepositoryItemPictureEdit()
		End Sub
	End Class
End Namespace
