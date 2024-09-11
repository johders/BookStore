using BookStore.Core.Interfaces;

namespace BookStore.Mobile.Services
{
	public class CommonService : ICommonService
	{
		public bool IsWeb => false;

		public bool ISMobile => true;
	}
}
