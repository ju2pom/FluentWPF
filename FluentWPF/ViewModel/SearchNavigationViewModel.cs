using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace FluentWPF.ViewModel
{
  public class SearchNavigationViewModel : ViewModelBase
  {
    private readonly SearchViewModel searchViewModel;
    private readonly Stack<SearchQuery> history;

    private int currentIndex;

    private class SearchQuery
    {
      public enum QueryType
      {
        Artist,
        Album,
        Title,
      }

      public SearchQuery(QueryType type, string text)
      {
        this.Type = type;
        this.Text = text;
      }
      
      public QueryType Type { get; }

      public string Text { get; }
    }

    public SearchNavigationViewModel(SearchViewModel searchViewModel)
    {
      this.searchViewModel = searchViewModel;
      this.history = new Stack<SearchQuery>();
      this.GoBackCommand = new RelayCommand(() => this.MoveInHistory(-1), this.CanGoBack);
      this.GoForwardCommand = new RelayCommand(() => this.MoveInHistory(1), this.CanGoForward);
    }

    private bool CanGoForward()
    {
      return this.currentIndex < this.history.Count - 1;
    }

    private void MoveInHistory(int step)
    {
      this.currentIndex += step;
      SearchQuery query = this.history.ElementAt(this.currentIndex);
      this.searchViewModel.Restore(query.Text);
    }

    private bool CanGoBack()
    {
      return this.currentIndex > 0;
    }

    public ICommand GoBackCommand { get; }

    public ICommand GoForwardCommand { get; }

    public void Push(string artistName)
    {
      if (this.currentIndex != this.history.Count - 1)
      {
        Enumerable
          .Range(this.currentIndex, this.history.Count - this.currentIndex)
          .ToList()
          .ForEach(x => this.history.Pop());
      }

      this.history.Push(new SearchQuery(SearchQuery.QueryType.Artist, this.searchViewModel.Search));
      this.currentIndex = this.history.Count - 1;
    }
  }
}
