﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18444
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


'
' This file contains the generated TableAdapter classes. 
' The strongly-typed dataset class is in the Data project.
'
Namespace QuestionsUserViewTableAdapters

    '''<summary>
    '''Represents the connection and commands used to retrieve and save data.
    '''</summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"), _
     Global.System.ComponentModel.ToolboxItem(True), _
     Global.System.ComponentModel.DataObjectAttribute(True), _
     Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" & _
        ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), _
     Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
    Partial Public Class QuestionsUserViewTableAdapter
        Inherits Global.System.ComponentModel.Component

        Private WithEvents _adapter As Global.System.Data.SqlClient.SqlDataAdapter

        Private _connection As Global.System.Data.SqlClient.SqlConnection

        Private _transaction As Global.System.Data.SqlClient.SqlTransaction

        Private _commandCollection() As Global.System.Data.SqlClient.SqlCommand

        Private _clearBeforeFill As Boolean

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Sub New()
            MyBase.New()
            Me.ClearBeforeFill = True
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Friend ReadOnly Property Adapter() As Global.System.Data.SqlClient.SqlDataAdapter
            Get
                If (Me._adapter Is Nothing) Then
                    Me.InitAdapter()
                End If
                Return Me._adapter
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Property Connection() As Global.System.Data.SqlClient.SqlConnection
            Get
                If (Me._connection Is Nothing) Then
                    Me.InitConnection()
                End If
                Return Me._connection
            End Get
            Set(value As Global.System.Data.SqlClient.SqlConnection)
                Me._connection = value
                If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                    Me.Adapter.InsertCommand.Connection = value
                End If
                If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                    Me.Adapter.DeleteCommand.Connection = value
                End If
                If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                    Me.Adapter.UpdateCommand.Connection = value
                End If
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    If (Not (Me.CommandCollection(i)) Is Nothing) Then
                        CType(Me.CommandCollection(i), Global.System.Data.SqlClient.SqlCommand).Connection = value
                    End If
                    i = (i + 1)
                Loop
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Property Transaction() As Global.System.Data.SqlClient.SqlTransaction
            Get
                Return Me._transaction
            End Get
            Set(value As Global.System.Data.SqlClient.SqlTransaction)
                Me._transaction = value
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    Me.CommandCollection(i).Transaction = Me._transaction
                    i = (i + 1)
                Loop
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.DeleteCommand) Is Nothing)) Then
                    Me.Adapter.DeleteCommand.Transaction = Me._transaction
                End If
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.InsertCommand) Is Nothing)) Then
                    Me.Adapter.InsertCommand.Transaction = Me._transaction
                End If
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.UpdateCommand) Is Nothing)) Then
                    Me.Adapter.UpdateCommand.Transaction = Me._transaction
                End If
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected ReadOnly Property CommandCollection() As Global.System.Data.SqlClient.SqlCommand()
            Get
                If (Me._commandCollection Is Nothing) Then
                    Me.InitCommandCollection()
                End If
                Return Me._commandCollection
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property ClearBeforeFill() As Boolean
            Get
                Return Me._clearBeforeFill
            End Get
            Set(value As Boolean)
                Me._clearBeforeFill = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitAdapter()
            Me._adapter = New Global.System.Data.SqlClient.SqlDataAdapter()
            Dim tableMapping As Global.System.Data.Common.DataTableMapping = New Global.System.Data.Common.DataTableMapping()
            tableMapping.SourceTable = "Table"
            tableMapping.DataSetTable = "QuestionsUserView"
            tableMapping.ColumnMappings.Add("SiteName", "SiteName")
            tableMapping.ColumnMappings.Add("Title", "Title")
            tableMapping.ColumnMappings.Add("Body", "Body")
            tableMapping.ColumnMappings.Add("Likes", "Likes")
            tableMapping.ColumnMappings.Add("Dislikes", "Dislikes")
            tableMapping.ColumnMappings.Add("MostCommonSummaryAdjective", "MostCommonSummaryAdjective")
            Me._adapter.TableMappings.Add(tableMapping)
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitConnection()
            Me._connection = New Global.System.Data.SqlClient.SqlConnection()
            Me._connection.ConnectionString = Global.DataAccess.My.MySettings.Default.EducationOverflowConnectionString
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitCommandCollection()
            Me._commandCollection = New Global.System.Data.SqlClient.SqlCommand(0) {}
            Me._commandCollection(0) = New Global.System.Data.SqlClient.SqlCommand()
            Me._commandCollection(0).Connection = Me.Connection
            Me._commandCollection(0).CommandText = "dbo.SelectQuestionsUserViewCommand"
            Me._commandCollection(0).CommandType = Global.System.Data.CommandType.StoredProcedure
            Me._commandCollection(0).Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.[Variant], 0, Global.System.Data.ParameterDirection.ReturnValue, 0, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, True)> _
        Public Overridable Overloads Function Fill(ByVal dataTable As Data.QuestionsUserView.QuestionsUserViewDataTable) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], True)> _
        Public Overridable Overloads Function GetData() As Data.QuestionsUserView.QuestionsUserViewDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            Dim dataTable As Data.QuestionsUserView.QuestionsUserViewDataTable = New Data.QuestionsUserView.QuestionsUserViewDataTable()
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class

    '''<summary>
    '''TableAdapterManager is used to coordinate TableAdapters in the dataset to enable Hierarchical Update scenarios
    '''</summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"), _
     Global.System.ComponentModel.ToolboxItem(True), _
     Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSD" & _
        "esigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), _
     Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapterManager")> _
    Partial Public Class TableAdapterManager
        Inherits Global.System.ComponentModel.Component

        Private _updateOrder As UpdateOrderOption

        Private _backupDataSetBeforeUpdate As Boolean

        Private _connection As Global.System.Data.IDbConnection

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property UpdateOrder() As UpdateOrderOption
            Get
                Return Me._updateOrder
            End Get
            Set(value As UpdateOrderOption)
                Me._updateOrder = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property BackupDataSetBeforeUpdate() As Boolean
            Get
                Return Me._backupDataSetBeforeUpdate
            End Get
            Set(value As Boolean)
                Me._backupDataSetBeforeUpdate = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), _
         Global.System.ComponentModel.Browsable(False)> _
        Public Property Connection() As Global.System.Data.IDbConnection
            Get
                If (Not (Me._connection) Is Nothing) Then
                    Return Me._connection
                End If
                Return Nothing
            End Get
            Set(value As Global.System.Data.IDbConnection)
                Me._connection = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), _
         Global.System.ComponentModel.Browsable(False)> _
        Public ReadOnly Property TableAdapterInstanceCount() As Integer
            Get
                Dim count As Integer = 0
                Return count
            End Get
        End Property

        '''<summary>
        '''Update rows in top-down order.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function UpdateUpdatedRows(ByVal dataSet As Data.QuestionsUserView, ByVal allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow), ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            Return result
        End Function

        '''<summary>
        '''Insert rows in top-down order.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function UpdateInsertedRows(ByVal dataSet As Data.QuestionsUserView, ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            Return result
        End Function

        '''<summary>
        '''Delete rows in bottom-up order.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function UpdateDeletedRows(ByVal dataSet As Data.QuestionsUserView, ByVal allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            Return result
        End Function

        '''<summary>
        '''Remove inserted rows that become updated rows after calling TableAdapter.Update(inserted rows) first
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function GetRealUpdatedRows(ByVal updatedRows() As Global.System.Data.DataRow, ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Global.System.Data.DataRow()
            If ((updatedRows Is Nothing) _
                        OrElse (updatedRows.Length < 1)) Then
                Return updatedRows
            End If
            If ((allAddedRows Is Nothing) _
                        OrElse (allAddedRows.Count < 1)) Then
                Return updatedRows
            End If
            Dim realUpdatedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow) = New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim i As Integer = 0
            Do While (i < updatedRows.Length)
                Dim row As Global.System.Data.DataRow = updatedRows(i)
                If (allAddedRows.Contains(row) = False) Then
                    realUpdatedRows.Add(row)
                End If
                i = (i + 1)
            Loop
            Return realUpdatedRows.ToArray
        End Function

        '''<summary>
        '''Update all changes to the dataset.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Overridable Function UpdateAll(ByVal dataSet As Data.QuestionsUserView) As Integer
            If (dataSet Is Nothing) Then
                Throw New Global.System.ArgumentNullException("dataSet")
            End If
            If (dataSet.HasChanges = False) Then
                Return 0
            End If
            Dim workConnection As Global.System.Data.IDbConnection = Me.Connection
            If (workConnection Is Nothing) Then
                Throw New Global.System.ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterMana" & _
                        "ger TableAdapter property to a valid TableAdapter instance.")
            End If
            Dim workConnOpened As Boolean = False
            If ((workConnection.State And Global.System.Data.ConnectionState.Broken) _
                        = Global.System.Data.ConnectionState.Broken) Then
                workConnection.Close()
            End If
            If (workConnection.State = Global.System.Data.ConnectionState.Closed) Then
                workConnection.Open()
                workConnOpened = True
            End If
            Dim workTransaction As Global.System.Data.IDbTransaction = workConnection.BeginTransaction
            If (workTransaction Is Nothing) Then
                Throw New Global.System.ApplicationException("The transaction cannot begin. The current data connection does not support transa" & _
                        "ctions or the current state is not allowing the transaction to begin.")
            End If
            Dim allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow) = New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow) = New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim adaptersWithAcceptChangesDuringUpdate As Global.System.Collections.Generic.List(Of Global.System.Data.Common.DataAdapter) = New Global.System.Collections.Generic.List(Of Global.System.Data.Common.DataAdapter)()
            Dim revertConnections As Global.System.Collections.Generic.Dictionary(Of Object, Global.System.Data.IDbConnection) = New Global.System.Collections.Generic.Dictionary(Of Object, Global.System.Data.IDbConnection)()
            Dim result As Integer = 0
            Dim backupDataSet As Global.System.Data.DataSet = Nothing
            If Me.BackupDataSetBeforeUpdate Then
                backupDataSet = New Global.System.Data.DataSet()
                backupDataSet.Merge(dataSet)
            End If
            Try
                '---- Prepare for update -----------
                '
                '
                '---- Perform updates -----------
                '
                If (Me.UpdateOrder = UpdateOrderOption.UpdateInsertDelete) Then
                    result = (result + Me.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows))
                    result = (result + Me.UpdateInsertedRows(dataSet, allAddedRows))
                Else
                    result = (result + Me.UpdateInsertedRows(dataSet, allAddedRows))
                    result = (result + Me.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows))
                End If
                result = (result + Me.UpdateDeletedRows(dataSet, allChangedRows))
                '
                '---- Commit updates -----------
                '
                workTransaction.Commit()
                If (0 < allAddedRows.Count) Then
                    Dim rows((allAddedRows.Count) - 1) As Global.System.Data.DataRow
                    allAddedRows.CopyTo(rows)
                    Dim i As Integer = 0
                    Do While (i < rows.Length)
                        Dim row As Global.System.Data.DataRow = rows(i)
                        row.AcceptChanges()
                        i = (i + 1)
                    Loop
                End If
                If (0 < allChangedRows.Count) Then
                    Dim rows((allChangedRows.Count) - 1) As Global.System.Data.DataRow
                    allChangedRows.CopyTo(rows)
                    Dim i As Integer = 0
                    Do While (i < rows.Length)
                        Dim row As Global.System.Data.DataRow = rows(i)
                        row.AcceptChanges()
                        i = (i + 1)
                    Loop
                End If
            Catch ex As Global.System.Exception
                workTransaction.Rollback()
                '---- Restore the dataset -----------
                If Me.BackupDataSetBeforeUpdate Then
                    Global.System.Diagnostics.Debug.Assert((Not (backupDataSet) Is Nothing))
                    dataSet.Clear()
                    dataSet.Merge(backupDataSet)
                Else
                    If (0 < allAddedRows.Count) Then
                        Dim rows((allAddedRows.Count) - 1) As Global.System.Data.DataRow
                        allAddedRows.CopyTo(rows)
                        Dim i As Integer = 0
                        Do While (i < rows.Length)
                            Dim row As Global.System.Data.DataRow = rows(i)
                            row.AcceptChanges()
                            row.SetAdded()
                            i = (i + 1)
                        Loop
                    End If
                End If
                Throw ex
            Finally
                If workConnOpened Then
                    workConnection.Close()
                End If
                If (0 < adaptersWithAcceptChangesDuringUpdate.Count) Then
                    Dim adapters((adaptersWithAcceptChangesDuringUpdate.Count) - 1) As Global.System.Data.Common.DataAdapter
                    adaptersWithAcceptChangesDuringUpdate.CopyTo(adapters)
                    Dim i As Integer = 0
                    Do While (i < adapters.Length)
                        Dim adapter As Global.System.Data.Common.DataAdapter = adapters(i)
                        adapter.AcceptChangesDuringUpdate = True
                        i = (i + 1)
                    Loop
                End If
            End Try
            Return result
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overridable Sub SortSelfReferenceRows(ByVal rows() As Global.System.Data.DataRow, ByVal relation As Global.System.Data.DataRelation, ByVal childFirst As Boolean)
            Global.System.Array.Sort(Of Global.System.Data.DataRow)(rows, New SelfReferenceComparer(relation, childFirst))
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overridable Function MatchTableAdapterConnection(ByVal inputConnection As Global.System.Data.IDbConnection) As Boolean
            If (Not (Me._connection) Is Nothing) Then
                Return True
            End If
            If ((Me.Connection Is Nothing) _
                        OrElse (inputConnection Is Nothing)) Then
                Return True
            End If
            If String.Equals(Me.Connection.ConnectionString, inputConnection.ConnectionString, Global.System.StringComparison.Ordinal) Then
                Return True
            End If
            Return False
        End Function

        '''<summary>
        '''Update Order Option
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Enum UpdateOrderOption

            InsertUpdateDelete = 0

            UpdateInsertDelete = 1
        End Enum

        '''<summary>
        '''Used to sort self-referenced table's rows
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Class SelfReferenceComparer
            Inherits Object
            Implements Global.System.Collections.Generic.IComparer(Of Global.System.Data.DataRow)

            Private _relation As Global.System.Data.DataRelation

            Private _childFirst As Integer

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
             Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub New(ByVal relation As Global.System.Data.DataRelation, ByVal childFirst As Boolean)
                MyBase.New()
                Me._relation = relation
                If childFirst Then
                    Me._childFirst = -1
                Else
                    Me._childFirst = 1
                End If
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
             Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Private Function GetRoot(ByVal row As Global.System.Data.DataRow, ByRef distance As Integer) As Global.System.Data.DataRow
                Global.System.Diagnostics.Debug.Assert((Not (row) Is Nothing))
                Dim root As Global.System.Data.DataRow = row
                distance = 0

                Dim traversedRows As Global.System.Collections.Generic.IDictionary(Of Global.System.Data.DataRow, Global.System.Data.DataRow) = New Global.System.Collections.Generic.Dictionary(Of Global.System.Data.DataRow, Global.System.Data.DataRow)()
                traversedRows(row) = row

                Dim parent As Global.System.Data.DataRow = row.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.[Default])

                Do While ((Not (parent) Is Nothing) _
                            AndAlso (traversedRows.ContainsKey(parent) = False))
                    distance = (distance + 1)
                    root = parent
                    traversedRows(parent) = parent
                    parent = parent.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.[Default])

                Loop

                If (distance = 0) Then
                    traversedRows.Clear()
                    traversedRows(row) = row
                    parent = row.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Original)

                    Do While ((Not (parent) Is Nothing) _
                                AndAlso (traversedRows.ContainsKey(parent) = False))
                        distance = (distance + 1)
                        root = parent
                        traversedRows(parent) = parent
                        parent = parent.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Original)

                    Loop
                End If

                Return root
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
             Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function Compare(ByVal row1 As Global.System.Data.DataRow, ByVal row2 As Global.System.Data.DataRow) As Integer Implements Global.System.Collections.Generic.IComparer(Of Global.System.Data.DataRow).Compare
                If Object.ReferenceEquals(row1, row2) Then
                    Return 0
                End If
                If (row1 Is Nothing) Then
                    Return -1
                End If
                If (row2 Is Nothing) Then
                    Return 1
                End If

                Dim distance1 As Integer = 0
                Dim root1 As Global.System.Data.DataRow = Me.GetRoot(row1, distance1)

                Dim distance2 As Integer = 0
                Dim root2 As Global.System.Data.DataRow = Me.GetRoot(row2, distance2)

                If Object.ReferenceEquals(root1, root2) Then
                    Return (Me._childFirst * distance1.CompareTo(distance2))
                Else
                    Global.System.Diagnostics.Debug.Assert(((Not (root1.Table) Is Nothing) _
                                    AndAlso (Not (root2.Table) Is Nothing)))
                    If (root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2)) Then
                        Return -1
                    Else
                        Return 1
                    End If
                End If
            End Function
        End Class
    End Class
End Namespace
