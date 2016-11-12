using System.ComponentModel.DataAnnotations;
using AreasResearch.Models.Pages;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AreasResearch.Areas.Site2.Models
{
    [ContentType(DisplayName = "Site2 Welcome Page", GUID = "4D4772CB-E2DE-401D-9CDA-913ABD928406", Description = "")]
    public class Site2WelcomePage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main content are",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentArea MainContentArea { get; set; }
    }
}
