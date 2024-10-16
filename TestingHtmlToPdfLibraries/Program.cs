using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using TestingHtmlToPdfLibraries.Converters;
using static Utils;
using TestingHtmlToPdfLibraries;

Console.WriteLine("HTML to PDF Conversion Test App");

//// Replace mergevalues
var html = InsertMergeValues.InsertMergeValueses(
    GetHtmlStringIda(),
    new
    {
        fornavn = "Winnie the",
        etternavn = "Winorg",
        adr2 = "Hundremeterskogen 1",
        poststed = "Namsskogan",
        postnr = "0100", 
        f_dato = "22.07.1990",
        startDato = "16.08.2024",
        stopDato = "20.08.2024",
        kursTittel = "Kurs i birøkt"
    }
);

//// Test PuppeteerSharp Conversion
var stream = await PuppeteerSharpConverter.ConvertToPdfAsync(html);

PdfDocument pdfDocument = PdfReader.Open(stream, PdfDocumentOpenMode.Modify);

// Modify the PDF metadata (Info dictionary)
pdfDocument.Info.Title = "My Custom Title";
pdfDocument.Info.Author = "";
pdfDocument.Info.Subject = "Generated PDF with Metadata";
pdfDocument.Info.Keywords = "Addoro:true,Channel:Postal,CustomerId 12345,ID:347563476,Name:Winnie the Winorg,Address1:hundremeterskogen 1,Address2:,PostalCode:0100,City:Skogen";

string outputPath = $"C:/outputstream_{DateTime.Now.ToString("HH_mm_ss")}.pdf";
pdfDocument.Save(outputPath);

Console.WriteLine("PDFs generated successfully.");


static class Utils
{
    public static Func<string> GetHtmlString = () =>
        """
            <table bgcolor="#efefef" border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #efefef;">
            <tbody><tr>
            <td bgcolor="#efefef" align="center" style="padding: 40px 0px 0px 0px;">
            <br /></td>
            </tr>
            <!-- LOGO -->
            <tr>
            <td bgcolor="#efefef" align="center" style="padding: 0px 10px 0px 10px;">

            <table align="center" border="0" cellspacing="0" cellpadding="0" width="800">
            <tbody><tr>
            <td align="center" valign="top" width="800">

            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width: 100%; max-width: 800px;">
            <tbody><tr>
            <td bgcolor="#ffffff" align="left" valign="top" style="padding: 30px 30px 60px 30px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tbody><tr>
            <td align="left" valign="top">
            <img alt="Logo Studieforbundet Livslang LÃƒÆ’Ã†â€™Ãƒâ€&nbsp;Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¦ring" src="http://sfll.no/wp-content/uploads/2021/09/logo_SFLL_SH-1024x375.png" width="150" height="55" style="display: block; font-family: Arial, sans-serif; color: #000000; font-size: 16px;" border="0"/>
            </td>
            <td align="right" valign="top">
            <img alt="Parat logo" src="https://www.parat.com/dm_images/parat-logo-link1.png" width="74" height="100" style="display: block; font-family: Arial, sans-serif; color: #000000; font-size: 16px;" border="0"/>
            </td>
            </tr>
            </tbody></table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <!-- TEXT -->
            <tbody><tr>
            <td bgcolor="#ffffff" align="left" style="padding: 60px 0px 0 0px; color: #000000; font-family: Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 1.3;">
            <h1 style="font-size: 46px; font-weight: 500; text-align: center; margin: 0 0 40px 0;">Kursbevis æ, ø, å</h1>
            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 0 0 0 0;">Parat medlem</p>
            <p style="font-size: 20px; font-weight: 700; text-align: center; margin: 0 0 20px 0;">{{fornavn}} {{etternavn}}<span style="background-color: #ffffff;"><br /></span><span style="background-color: #efefef;">{{f_dato}}</span></p>
            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 0 0 20px 0;">Har i perioden {{startDato}} - {{stopDato}} gjennomgått</p>
            <p style="font-size: 20px; font-weight: 700; text-align: center; margin: 0 0 20px 0;">{{kurstittel}}</p>
            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 0 0 20px 0;">Kursets Innhold</p>
            </td>
            </tr>
            <!-- TEXT -->
            <tr>
            <td bgcolor="#ffffff" align="left" style="padding: 0 30px 0px 30px; color: #000000; font-family: Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 1.3;">
            <div>Grunnopplæringen har omhandlet rollen som tillitsvalgt, kollektiv og individuell arbeidsrett, og inneholder en gjennomgang av gjeldende lov og avtaleverk. 
            Det har vært særlig fokus på følgende temaer:  </div>
            <p style="font-size: 16px; font-weight: 400;">
            </p><ul>
            <li>Rollen som tillitsvalgt.</li>
            <li>Klubbdrift</li>
            <li>Arbeidsgivers styringsrett</li>
            <li>Arbeidsgivers og arbeidstakers plikter i ansettelsesforholdet</li>
            <li>Lønnsforhandlinger</li>
            <li>Medbestemmelse og omstillinger på&nbsp;arbeidsplassen.</li>
            </ul>
            <p></p>

            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 60px 0 40px 0;">Oslo, [stop_dato]<br /></p>
            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 0 0 0 0;">Med vennlig hilsen</p>
            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 0 0 60px 0;">Parat kursadministrasjon</p>
            <p style="font-size: 20px; font-weight: 400; text-align: center; margin: 0 0 10px 0;"><a style="font-size: 16px; font-weight: 600; color: #dd4815;" href="https://www.parat.com" target="_blank">Parat - et YS forbund</a> </p>
            </td>
            </tr>
            </tbody></table>
            </td>
            </tr>
            </tbody></table>

            </td>
            </tr>
            </tbody></table>

            </td>
            </tr>
            <tr>
            <td bgcolor="#efefef" align="center" style="padding: 0px 0px 100px 0px;"> <br /></td>
            </tr>
            </tbody></table>

         """;

    public static Func<string> GetHtmlStringIda = () =>

    """

        <p>{{fornavn}} {{etternavn}}&nbsp;<br>{{adr2}}&nbsp;<br>{{postnr}} {{poststed}}&nbsp;</p>
    <p style="text-align: right;">Dato</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <h1>Overskrift, {{fornavn}}&nbsp;</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nec ultrices sem, nec laoreet ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis eu arcu elit. Aenean luctus tortor quis massa venenatis, non scelerisque purus ullamcorper. Quisque aliquam dapibus sagittis. Quisque porta semper hendrerit. Sed placerat aliquet dolor, eget accumsan odio iaculis id. Cras sed nisi leo. Curabitur tincidunt, enim quis pretium semper, orci velit efficitur ipsum, sit amet porta sapien mi eget augue. Morbi lacinia aliquet tellus eu posuere. Nulla elementum ipsum dui, in malesuada urna vulputate in.</p>
    <p>Morbi vehicula eleifend hendrerit. Nulla vel porttitor risus, eget interdum velit. Donec fermentum venenatis suscipit. Sed in auctor nunc. Phasellus lobortis libero sed ex molestie luctus. Nullam a quam rhoncus, efficitur tellus in, facilisis tellus. Mauris et metus quis purus luctus sollicitudin in aliquet arcu. Suspendisse ultrices egestas ipsum id condimentum. Nulla et augue tellus. Morbi ultricies diam eu augue molestie, vel dapibus turpis fringilla. In egestas consectetur velit, eu imperdiet nisi mollis vitae.</p>
    <p><img src="https://winorg.no/media/ld5jmm0y/skjermbilde-2022-10-10-142706.png" alt="" width="623" height="350"></p>
    <p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed dignissim lacinia odio vehicula vulputate. Duis convallis odio quis dolor facilisis aliquam ut id sapien. Vivamus mattis sapien felis, at commodo purus ultricies eget. Donec molestie porta suscipit. Phasellus a nunc auctor, faucibus nisi ut, imperdiet sem. Quisque ut diam vestibulum, iaculis lectus id, accumsan lorem. Aenean pulvinar dapibus turpis sit amet feugiat.</p>
    <p>Donec faucibus aliquet ligula, et gravida turpis ullamcorper eu. Suspendisse potenti. Vestibulum finibus cursus vulputate. Aenean ut aliquam magna. Etiam velit dolor, efficitur porttitor porta a, auctor at tortor. Vestibulum vel mauris in tellus facilisis ornare ac vel lacus. Nam orci libero, varius in convallis id, accumsan nec enim. Cras accumsan ipsum ac mauris tempor, vel faucibus tortor rhoncus. Aenean feugiat eros a maximus euismod. Morbi suscipit lorem egestas erat semper venenatis. Phasellus iaculis, ante a consequat sollicitudin, nisl mi egestas augue, quis consequat velit elit ut odio. Aliquam neque nunc, vulputate vel accumsan sed, mattis a arcu. Curabitur pulvinar id dolor at porttitor. Maecenas lectus neque, finibus vulputate venenatis ac, maximus eget lectus.</p>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nec ultrices sem, nec laoreet ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis eu arcu elit. Aenean luctus tortor quis massa venenatis, non scelerisque purus ullamcorper. Quisque aliquam dapibus sagittis. Quisque porta semper hendrerit. Sed placerat aliquet dolor, eget accumsan odio iaculis id. Cras sed nisi leo. Curabitur tincidunt, enim quis pretium semper, orci velit efficitur ipsum, sit amet porta sapien mi eget augue. Morbi lacinia aliquet tellus eu posuere. Nulla elementum ipsum dui, in malesuada urna vulputate in.</p>
    <p>Morbi vehicula eleifend hendrerit. Nulla vel porttitor risus, eget interdum velit. Donec fermentum venenatis suscipit. Sed in auctor nunc. Phasellus lobortis libero sed ex molestie luctus. Nullam a quam rhoncus, efficitur tellus in, facilisis tellus. Mauris et metus quis purus luctus sollicitudin in aliquet arcu. Suspendisse ultrices egestas ipsum id condimentum. Nulla et augue tellus. Morbi ultricies diam eu augue molestie, vel dapibus turpis fringilla. In egestas consectetur velit, eu imperdiet nisi mollis vitae.</p>
    <p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed dignissim lacinia odio vehicula vulputate. Duis convallis odio quis dolor facilisis aliquam ut id sapien. Vivamus mattis sapien felis, at commodo purus ultricies eget. Donec molestie porta suscipit. Phasellus a nunc auctor, faucibus nisi ut, imperdiet sem. Quisque ut diam vestibulum, iaculis lectus id, accumsan lorem. Aenean pulvinar dapibus turpis sit amet feugiat.</p>
    <p>Donec faucibus aliquet ligula, et gravida turpis ullamcorper eu. Suspendisse potenti. Vestibulum finibus cursus vulputate. Aenean ut aliquam magna. Etiam velit dolor, efficitur porttitor porta a, auctor at tortor. Vestibulum vel mauris in tellus facilisis ornare ac vel lacus. Nam orci libero, varius in convallis id, accumsan nec enim. Cras accumsan ipsum ac mauris tempor, vel faucibus tortor rhoncus. Aenean feugiat eros a maximus euismod. Morbi suscipit lorem egestas erat semper venenatis. Phasellus iaculis, ante a consequat sollicitudin, nisl mi egestas augue, quis consequat velit elit ut odio. Aliquam neque nunc, vulputate vel accumsan sed, mattis a arcu. Curabitur pulvinar id dolor at porttitor. Maecenas lectus neque, finibus vulputate venenatis ac, maximus eget lectus.</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <!-- pagebreak -->
    <p style="page-break-after: always;">&nbsp;</p>
    <h1>Ny side</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nec ultrices sem, nec laoreet ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis eu arcu elit. Aenean luctus tortor quis massa venenatis, non scelerisque purus ullamcorper. Quisque aliquam dapibus sagittis. Quisque porta semper hendrerit. Sed placerat aliquet dolor, eget accumsan odio iaculis id. Cras sed nisi leo. Curabitur tincidunt, enim quis pretium semper, orci velit efficitur ipsum, sit amet porta sapien mi eget augue. Morbi lacinia aliquet tellus eu posuere. Nulla elementum ipsum dui, in malesuada urna vulputate in.</p>
    <p>Morbi vehicula eleifend hendrerit. Nulla vel porttitor risus, eget interdum velit. Donec fermentum venenatis suscipit. Sed in auctor nunc. Phasellus lobortis libero sed ex molestie luctus. Nullam a quam rhoncus, efficitur tellus in, facilisis tellus. Mauris et metus quis purus luctus sollicitudin in aliquet arcu. Suspendisse ultrices egestas ipsum id condimentum. Nulla et augue tellus. Morbi ultricies diam eu augue molestie, vel dapibus turpis fringilla. In egestas consectetur velit, eu imperdiet nisi mollis vitae.</p>
    <p><img src="https://winorg.no/media/ld5jmm0y/skjermbilde-2022-10-10-142706.png" alt="" width="623" height="350"></p>
    <p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed dignissim lacinia odio vehicula vulputate. Duis convallis odio quis dolor facilisis aliquam ut id sapien. Vivamus mattis sapien felis, at commodo purus ultricies eget. Donec molestie porta suscipit. Phasellus a nunc auctor, faucibus nisi ut, imperdiet sem. Quisque ut diam vestibulum, iaculis lectus id, accumsan lorem. Aenean pulvinar dapibus turpis sit amet feugiat.</p>
    <p>Donec faucibus aliquet ligula, et gravida turpis ullamcorper eu. Suspendisse potenti. Vestibulum finibus cursus vulputate. Aenean ut aliquam magna. Etiam velit dolor, efficitur porttitor porta a, auctor at tortor. Vestibulum vel mauris in tellus facilisis ornare ac vel lacus. Nam orci libero, varius in convallis id, accumsan nec enim. Cras accumsan ipsum ac mauris tempor, vel faucibus tortor rhoncus. Aenean feugiat eros a maximus euismod. Morbi suscipit lorem egestas erat semper venenatis. Phasellus iaculis, ante a consequat sollicitudin, nisl mi egestas augue, quis consequat velit elit ut odio. Aliquam neque nunc, vulputate vel accumsan sed, mattis a arcu. Curabitur pulvinar id dolor at porttitor. Maecenas lectus neque, finibus vulputate venenatis ac, maximus eget lectus.</p>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nec ultrices sem, nec laoreet ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis eu arcu elit. Aenean luctus tortor quis massa venenatis, non scelerisque purus ullamcorper. Quisque aliquam dapibus sagittis. Quisque porta semper hendrerit. Sed placerat aliquet dolor, eget accumsan odio iaculis id. Cras sed nisi leo. Curabitur tincidunt, enim quis pretium semper, orci velit efficitur ipsum, sit amet porta sapien mi eget augue. Morbi lacinia aliquet tellus eu posuere. Nulla elementum ipsum dui, in malesuada urna vulputate in.</p>
    <p>Morbi vehicula eleifend hendrerit. Nulla vel porttitor risus, eget interdum velit. Donec fermentum venenatis suscipit. Sed in auctor nunc. Phasellus lobortis libero sed ex molestie luctus. Nullam a quam rhoncus, efficitur tellus in, facilisis tellus. Mauris et metus quis purus luctus sollicitudin in aliquet arcu. Suspendisse ultrices egestas ipsum id condimentum. Nulla et augue tellus. Morbi ultricies diam eu augue molestie, vel dapibus turpis fringilla. In egestas consectetur velit, eu imperdiet nisi mollis vitae.</p>
    <p>Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed dignissim lacinia odio vehicula vulputate. Duis convallis odio quis dolor facilisis aliquam ut id sapien. Vivamus mattis sapien felis, at commodo purus ultricies eget. Donec molestie porta suscipit. Phasellus a nunc auctor, faucibus nisi ut, imperdiet sem. Quisque ut diam vestibulum, iaculis lectus id, accumsan lorem. Aenean pulvinar dapibus turpis sit amet feugiat.</p>
    <p>Donec faucibus aliquet ligula, et gravida turpis ullamcorper eu. Suspendisse potenti. Vestibulum finibus cursus vulputate. Aenean ut aliquam magna. Etiam velit dolor, efficitur porttitor porta a, auctor at tortor. Vestibulum vel mauris in tellus facilisis ornare ac vel lacus. Nam orci libero, varius in convallis id, accumsan nec enim. Cras accumsan ipsum ac mauris tempor, vel faucibus tortor rhoncus. Aenean feugiat eros a maximus euismod. Morbi suscipit lorem egestas erat semper venenatis. Phasellus iaculis, ante a consequat sollicitudin, nisl mi egestas augue, quis consequat velit elit ut odio. Aliquam neque nunc, vulputate vel accumsan sed, mattis a arcu. Curabitur pulvinar id dolor at porttitor. Maecenas lectus neque, finibus vulputate venenatis ac, maximus eget lectus.</p>
    
    <p style="page-break-after: always;">&nbsp;</p>
    <h1>Ny side 2</h1>

    <p style="page-break-after: always;">&nbsp;</p>
    <h1>Ny side 3</h1>
    """;
}