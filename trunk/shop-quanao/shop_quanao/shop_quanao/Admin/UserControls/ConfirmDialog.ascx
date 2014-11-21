<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmDialog.ascx.cs" Inherits="shop_quanao.Admin.UserControls.ConfirmDialog" %>

<style type="text/css">
    .showmodal
    {
        margin: auto;
        width: 500px;
        z-index: 9003;
        position: absolute; /*background-color:White;*/
        display: block;
        top: 35%;
        left: 0;
        bottom: 0;
        right: 0;
    }
    
    .hidemodal
    {
        display: none;
    }
    
    .OverlayEffect
    {
        background-color: black;
        filter: alpha(opacity=70);
        opacity: 0.7;
        width: 100%;
        height: 100%;
        z-index: 9002;
        position: absolute;
        top: 0;
        left: 0;
    }
</style>
<script type="text/javascript">
    function DisplayModal() {
        document.getElementById("overlay").style.height = document.body.cl + 'px';
        document.getElementById("overlay").className = "OverlayEffect";
        document.getElementById("modalMsg").style.left = Math.round(document.body.width / 2) - 250 + 'px';
        document.getElementById("modalMsg").className = "showmodal";
        //document.getElementById("modalMsg").style.margen = document.body.width + 'px';       
    }

    function RemoveModal() {
        document.getElementById("modalMsg").className = "hidemodal";
        document.getElementById("overlay").className = "";
        return;
    }
</script>
<div id="overlay" class="OverlayEffect">
</div>
<div align="center">
    <div id="modalMsg" class="widgets ui-sortable showmodal">
        <div class="widget sortable table" style="opacity: 1;">
            <h3 class="handle">
                <%=DialogTitle %>
            </h3>
            <div>
                <p style="text-align: center">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Blue"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Yes" Width="80px" CssClass="button"
                        OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="No" Width="80px" CssClass="button"
                        OnClick="btnCancel_Click" />
                </p>
            </div>
        </div>
    </div>
</div>
