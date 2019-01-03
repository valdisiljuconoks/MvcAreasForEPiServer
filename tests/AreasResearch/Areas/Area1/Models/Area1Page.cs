using System.ComponentModel.DataAnnotations;
using AreasResearch.Models.Pages;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AreasResearch.Areas.Area1.Models
{
    [ContentType(DisplayName = "Area1Page", GUID = "23829cfd-1467-4645-9b65-f4442c003053", Description = "")]
    public class Area1Page : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 320)]
        [CultureSpecific]
        public virtual ContentArea MainContentArea { get; set; }
    }
}
