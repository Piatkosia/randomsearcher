using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;
namespace GeneratorPlaylisty
{
	class cmdOpt
	{
    [Option('s', "source", Required = true, HelpText = "Folder źródłowy")]
      public string Source { get; set; }

  [Option('c', "count", DefaultValue = 0, HelpText = "Ilość elementów w przygotowanej liście")]
  public int Count { get; set; }

  
  [Option('d', "saveas", HelpText = "Plik wynikowy (ścieżka)")]
  public string  Dest { get; set; }
  [Option('h', "help", HelpText = "Wyświetla pomoc")]
  public bool pomocy { get; set; }
	}
}
