using System.ComponentModel.DataAnnotations;
using AreasResearch.Models.Pages;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AreasResearch.Areas.Site1.Models
{
    [ContentType(DisplayName = "Site1 Welcome Page", GUID = "b1d03580-2c89-4e26-b091-94affea5e004", Description = "")]
    public class Site1WelcomePage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main content are",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentArea MainContentArea { get; set; }
    }
}
