#pragma checksum "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Areas\Admin\Views\Writer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "070bd8458bce7e497eb7a9cfdc9c10efa32de190"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Writer_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Writer/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"070bd8458bce7e497eb7a9cfdc9c10efa32de190", @"/Areas/Admin/Views/Writer/Index.cshtml")]
    public class Areas_Admin_Views_Writer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Areas\Admin\Views\Writer\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h1>Yazar AJAX İşlemleri</h1>
<br />
<button type=""button"" id=""btngetlist"" class=""btn btn-outline-primary"">Yazar Listesi</button>
<!--ajax kullanımı için
    html elemanına id vermem gerekiyor.
    çünkü js'de ajax'de
    id ile html elemanlarını kullanırım-->
<button type=""button"" id=""btngetbyid"" class=""btn btn-outline-success"">Yazar Getir</button><!--id'ye göre yazar getirecek buton'-->
<!--AJAX ile Yazar ekleme butonu-->
<button type=""button"" id=""btnAddWriter"" class=""btn btn-outline-info"">Yazar Ekle</button>
<!--AJAX ile Yazar silme butonu-->
<button type=""button"" id=""btnDeleteWriter"" class=""btn btn-outline-danger"">Yazar Sil</button>
<!--AJAX ile Yazar güncelleme butonu-->
<button type=""button"" id=""btnUpdateWriter"" class=""btn btn-outline-warning"">Yazar Güncelle</button>
<br />
<br />
<div id=""writerlist"">
    Buraya yazarlar gelecek


</div>
<div id=""writerget"">
    Buraya id'si verilen  yazar gelecek
</div>

<br />
<!--yazar ekleme alanı-->
<div>
    <h2>Yazar Ekleme</h2>
");
            WriteLiteral(@"
    <input type=""text"" class=""form-control"" id=""txtwriterid"" placeholder=""Yazar ID"" />
    <input type=""text"" class=""form-control"" id=""txtwritername"" placeholder=""Yazar Adı"" />
</div>
<!--yazar silme alanı-->
<div>
    <h2>Yazar Silme</h2>
    <input type=""text"" class=""form-control"" id=""txtid"" placeholder=""Silinecek Yazar ID"" />
</div>
<br />
<!--yazar güncelleme alanı-->
<div>
    <h2>Yazar Güncelleme</h2>
    <input type=""text"" class=""form-control"" id=""txtid1"" placeholder=""Güncellenecek Yazar ID"" />
    <input type=""text"" class=""form-control"" id=""txtwritername1"" placeholder=""Güncellenecek Yazar Adı"" />
</div>

<!--ID'ye Göre Yazar Getirme-->
<div>
    <h2>ID'ye Göre Yazar Getirme</h2>
    <input type=""text"" id=""writerid"" placeholder=""Yazar ID Değerini Girin."" />
    <!--buradaki id değerinin controllerun aldığı parametre ile aynı olmalı
        Bu butona tıkladığı zaman burada girilen id'ye sahip yazar bilgileri gelecek.
        AJAX kullanacağız.'-->

</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <!---admin layout içinde scripts adını vererek komut tanımlamıştım
        buraya o scripts adını yazdım.-->
    <script>
        //şimdi buraya script kodlara yazacağım
        //yazar listeleme ajax
        $(""#btngetlist"").click(function () {
            //buraya tetiklenecek aracın id'sini yazacağım. yukarıda tıklanınca yazarların listeleneceği
            //html butonun id'sine btngetlist adını vermiştim.  şimdi o id'li elemana script yazacağımı belirtiyorum
            //.click ile o id'li butona tıklandığı zaman bu fonksiyon çalışsın, bu işlemleri yapsın diyorum
            //ve şimdi ajax kodlarını yazalım
            $.ajax({
                //ajaxa ait parametreleri yazalım
                contentType: ""application/json"",//burada uygulama türünü yazdım
                dataType: ""json"",//dönen verinin türü
                type: ""Get"",//Get olduğu zaman çalışsın
                url: ""/Admin/Writer/WriterList/"",//url'e ise çalışacak olan backend fonksiyonunun, action'unun bulunduğu");
                WriteLiteral(@" konumu veriyorum
                //Yani butona tıklanınca Admin içinde Writer controller'unda yer alan WriterList action result'ı çalışsın diyorum.
                success: function (func) {//eğer işlem başarılı olursa func isimli bir fonksiyon döndürsün
                    let w = jQuery.parseJSON(func);//func'dan gelen değeri json'a dönüştürür.
                    console.log(w);//bu fonksiyon konsola w gelen değerleri yazdırır.

                    //ben verileri console yerine tablo da listelemek istiyorum
                    let tablehtml = ""<table class=table table-bordered> <tr> <th>Yazar ID</th> <th>Yazar Adı</th></tr >"";

                    $.each(w, (index, value) => {
                        tablehtml += `<tr><td>${value.Id}</td> <td>${value.name}</td> </tr>`
                        //tablehtml değişkenini oluşturmuştum. bu tabloya verileri listelemek için altgr+;tuşuna basıyorum
                        //bu işaret içine tablo oluşturup içinde WriterClass'ımın verilerini Id ve name de");
                WriteLiteral(@"ğerlerini
                        //value ile listeletiyorum.


                    });
                    //artık şimdi verilerin tabloya yansıtılması işlemini yazalım.
                    tablehtml += ""</table>"";//bunu tabloyu yukarıda oluşturup içine dahil ederekde yapabiliriz
                    $(""#writerlist"").html(tablehtml);//html içinde tablehtml'den geleni yansıtır.
                    //writerlist id'sini verdiğim div bloğunun içinde tablo olarak yazarları yansıtsın dedim.




                }





            });


        });
        //yazar id'ye göre listeleme ajax
        $(""#btngetbyid"").click(x => {
            let id = $(""#writerid"").val();//writerid id değerli input html elemanından gelecek olan değeri val ile okur
            //console.log(id);
            $.ajax({
                contentType: ""application/json"",
                datatype: ""json"",
                type: ""get"",
                url: ""/Admin/Writer/GetWriterByID/"",//id'ye göre listeleme yapan G");
                WriteLiteral(@"etWriterByID metodunu çağırır.
                data: { writerid: id },//burada dışarıdan data da alıyoruz. Bu yüzden dataya
                //burada writerid inputtan gelen id değeri dışarıdan gönderilen id parametresine karşılık gelecek. (yani veritabanındaki id'ye)
                success: function (func) {
                    let w = jQuery.parseJSON(func);//func'dan gelen değeri json'a dönüştürür.


                    console.log(w);//gönderilen id'ye göre verileri getirir.
                    let getValue = `<table class=table table-bordered> <tr><th>Yazar ID</th><th>Yazar Adı</th></tr><tr><td>${w.Id}</td>
                                        <td>${w.name}</td></tr></table>`;//tabloya gelen değerleri yansıtır.
                    $(""#writerget"").html(getValue);//id değerine writerget adını verdiğim div içinde bu getvalue tablosunu koyar.
                }
            });
        });
        //yazar ekleme ajax script kodu
        $(""#btnAddWriter"").click(function () {//buton adını verd");
                WriteLiteral(@"im. Çünkü bu butona tıkladığı zaman ajax kodu çalışıp işlem yapacak.
            let writer = {
                //eklenecek parametreler
                Id: $(""#txtwriterid"").val(),//entity'de yer alan Id property değerinin karşılığı html elemanda txtwriterid id değerine sahip
                //html input elemanıdır diyorum. Yani txt'den gelen değeri alır. Ve bunu WriterClass sınıfındaki yani entity'deki değere atar.
                //Sol taraf entitydeki ad ile aynı olmalı.
                name: $(""#txtwritername"").val()

            };
            $.ajax({
                type: ""post"",//ekleme işlemi olduğu içni type'ı post olur. Okuma,listeleme olsa get olurdu.
                url: ""/Admin/Writer/AddWriter/"",
                data: writer,//yukarıda tanımladığım writer değişkeninden gelen değer datam olur.
                success: function (func) {
                    let result = jQuery.parseJSON(func);
                    alert(""Yazar ekleme işlemi başarılı bir şekilde gerçekleşti."");

  ");
                WriteLiteral(@"              }



            });
        });
        //yazar silme ajax script kodu
        $(""#btnDeleteWriter"").click(x => {
            let id = $(""#txtid"").val();//silinecek olan id değeri. silinecek değeri
            //txtid'si id değerine sahip input veriyor. O yüzden onun id'sini verdim.
            $.ajax({
                url: ""/Admin/Writer/DeleteWriter/"" + id,//url silinecek id'yide parametre olarak alıyor.
                type: ""post"",//post işlemine bağlı çalışacak
                dataType: ""json"",
                success: function (func) {
                    //loadData();//verileri yükle bu veriyi döndürür
                    //Veriyi döndürmek yerine mesaj verdirelim.
                    let result = jQuery.parseJSON(func);
                    alert(""Yazar silme işlemi başarılı bir şekilde gerçekleşti"");
                }

            });

        });
        //yazar güncelleme ajax script kodu
        $(""#btnUpdateWriter"").click(function () {
            let write");
                WriteLiteral(@"r = {
                //güncellenecek yeni değerler inputtan alınan değerler
                Id: $(""#txtid1"").val(),
                name: $(""#txtwritername1"").val()

            };
            //şimdi ajax tarafını yazalım
            $.ajax({
                type: ""post"",
                url: ""/Admin/Writer/UpdateWriter/"",//controller içinde yer alan çalıştırılacak metod
                data: writer,//data yukarıda tanımladığım yeni değerleri verdiğim writer olacak
                success: function (func) {
                    alert(""Güncelleme başarıyla yapıldı"");
                }


            });
        });
    </script>



");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
