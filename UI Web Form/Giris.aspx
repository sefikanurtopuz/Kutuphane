<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="UI_Web_Form.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Yap</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }

        img {
            border-radius: 50%;
            height: 150px;
            width: 150px;
            object-fit: cover;
        }
    </style>
    <link href="css/signin.css" rel="stylesheet" />
</head>
<body class="text-center">
    <%--<form id="form1" runat="server">
        <div>
        </div>
    </form>--%>
    <main class="form-signin">
        <form runat="server">
            <img class="mb-4" src="images/logo.gif" alt="" />
            <h1 class="h3 mb-3 fw-normal">Giriş Yap</h1>

            <div class="form-floating">
                <asp:TextBox ID="txtKullaniciAdi" runat="server" type="text" class="form-control" placeholder="Kullanıcı Adı"></asp:TextBox>
                <label for="floatingInput">Kullanıcı Adı</label>
            </div>

            <div class="form-floating">
                <asp:TextBox ID="txtSifre" runat="server" type="password" class="form-control" placeholder="Şifre"></asp:TextBox>
                <label for="floatingPassword">Şifre</label>
            </div>

            <asp:Button ID="btnGirisYap" runat="server" Text="Giriş Yap" class="w-100 btn btn-lg btn-primary" type="submit" OnClick="btnGirisYap_Click" />
            <p class="mt-5 mb-3 text-muted">&copy; Şefika Nur Topuz | 2022 </p>

        </form>

         <br />
    <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
        <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
            <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
        </symbol>
    </svg>
    <asp:Panel ID="PanelHata" runat="server" Visible="False">
        <div class="alert alert-danger d-flex align-items-center" role="alert">
            <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:">
                <use xlink:href="#exclamation-triangle-fill" />
            </svg>
            <div>
                <asp:Label ID="lblHata" runat="server" Text="Hatalı giriş denmesi!"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    </main>

</body>
</html>
