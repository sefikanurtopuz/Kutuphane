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
                <asp:TextBox ID="txtKullaniciAdi" runat="server" type="email" class="form-control" placeholder="Kullanıcı Adı"></asp:TextBox>
                <label for="floatingInput">Kullanıcı Adı</label>
            </div>

            <div class="form-floating">
                <asp:TextBox ID="txtSifre" runat="server" type="password" class="form-control" placeholder="Şifre"></asp:TextBox>
                <label for="floatingPassword">Şifre</label>
            </div>

            <asp:Button ID="btnGirisYap" runat="server" Text="Giriş Yap" class="w-100 btn btn-lg btn-primary" type="submit" />
            <p class="mt-5 mb-3 text-muted">&copy; Şefika Nur Topuz | 2022 </p>

        </form>
    </main>

</body>
</html>
