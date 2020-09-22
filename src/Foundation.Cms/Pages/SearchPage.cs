using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Foundation.Cms.Pages
{
    [ContentType(DisplayName = "Search Page By Tags",
        GUID = "FD752044-9EA1-464C-8B64-1007375FC383",
        Description = "Search Page, which produce search by tags",
        GroupName = CmsGroupNames.Search)]
    [ImageUrl("~/assets/icons/cms/pages/CMS-icon-page-03.png")]
    public class SearchPage : PageData
    {

    }
}
