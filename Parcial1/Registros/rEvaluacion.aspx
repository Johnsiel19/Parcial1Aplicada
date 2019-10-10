<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rEvaluacion.aspx.cs" Inherits="Parcial1.rEvaluacion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Evaluacion</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--EvaluacionID--%>
                    <div class="form-group">
                        <label for="EstudianteIdlabel" class="col-md-3 control-label input-sm" style="font-size: small">EvaluacionId </label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="EvaluacionIdTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                         <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="EvaluacionIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:Button CssClass="col-md-1 btn btn-primary btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                        <%--Fecha--%>
                        <label for="fechaTextBox" class="col-md-1 control-label input-sm">Fecha: </label>
                        <div class="col-md-3">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                    </div>

            
                     <%--Estudiante--%>
                    <div class="form-group">
                        <label for="Estudiantelabel" class="col-md-3  control-label input-sm" style="font-size: small">Estudiante</label>
                        <div class="col-md-3">
                            <asp:TextBox runat="server" ID="EstudianteDropDownList" CssClass="form-control input-sm" AutoPostBack="true" ValidationGroup="Guardar"></asp:TextBox>
                        </div>
                    </div>

                    <%--Valores al grid--%>
                   
                    <div class="form-group">


                        <div class="col-md-3 col-md-offset-2">
                            <asp:Label ID="CategoriaDropDownListlabel" Text="Servicio" Style="font-size: small" runat="server" />
                            <asp:TextBox runat="server" ID="ServicioDropDownList" CssClass="form-control input-sm" AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVId" ValidationGroup="Buscar" ControlToValidate="ServicioDropDownList" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-2 ">
                            <asp:Label ID="CantidadLabel" Text="Cantidad" runat="server" />
                            <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Buscar" ControlToValidate="CantidadTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-2 ">
                            <asp:Label ID="PrecioLabel" Text="Precio" runat="server" />
                            <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Buscar" ControlToValidate="PrecioTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2 ">
                            <asp:Label ID="Label1" Text="Importe" runat="server" />
                            <asp:TextBox ID="ImporteTextBox" ReadOnly ="true" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Buscar" ControlToValidate="ImporteTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        

                        <div class="col-sm-1">
                             <asp:Button ID="AgregarButton" runat="server" Text="Agregar" class="btn btn-success" ValidationGroup="Agregar" OnClick="AgregarButton_Click"  />
                        </div>
                    </div>



         <div class="form-horizontal col-md-12" role="form">
                    
            <%--GRID--%>
                <asp:GridView ID="Grid" CssClass=" col-md-offset-2 col-md-offset-2" runat="server" AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="false" AutoGenerateDeleteButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="767px" AutoGenerateColumns="false" OnRowDeleting="Grid_RowDeleting1" >                         
                    <Columns>
                        <asp:BoundField DataField="EvaluacionId" HeaderText="EvaluacionId" /><asp:BoundField />
                        <asp:BoundField DataField="Servicio" HeaderText="CategoriaId" /><asp:BoundField />
                        <asp:BoundField DataField="Cantidad" HeaderText="Valor" /><asp:BoundField />
                        <asp:BoundField DataField="Precio" HeaderText="Logrados" /><asp:BoundField />
                        <asp:BoundField DataField="Importe" HeaderText="Peridos" /><asp:BoundField />

                       


                       
                    </Columns>     
                    <EmptyDataTemplate><div style="text-align:center">No hay datos en el Grid.</div></EmptyDataTemplate>
                         <AlternatingRowStyle BackColor="White" />

                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>

             

                    <%--Puntos Perdidos--%>
                    <div class="form-group">
                        <label for="PuntosPerdidosTextBox" class="col-md-8 control-label input-sm" style="font-size: small">Total</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="TotalTextBox" ReadOnly ="true" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                        </div>
                    
                    </div>

             </div>
                </div>
            </div>

        </div>

         <%--botones--%>
         <div class="panel">
             <div class="text-center">
                 <div class="form-group">
                     <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click" />
                     <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click"  />
                     <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click"  />
                 </div>
             </div>
         </div>
    </div>


</asp:Content>
