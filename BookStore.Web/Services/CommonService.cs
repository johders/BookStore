using BookStore.Core.Interfaces;

namespace BookStore.Web.Services
{
	public class CommonService : ICommonService
	{
		public bool IsWeb => true;

		public bool ISMobile => false;
	}
}
