﻿namespace BookStore.Core.Interfaces
{
    public interface ICommonService
    {
        bool IsWeb { get; }
        bool IsMobile { get; }
		void ShowLoader(string loaderMessage) { }
		void HideLoader() { }
	}
}
