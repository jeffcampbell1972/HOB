Overview
--------

The HOB application was written to demonstrate proficiency (or lack thereof) in utilizing the .NET Core 3 framework.  It was created using the "ASP.Net Core Web Application" template in
Visual Studio 2019 and currently utilizes the following features:

	- Basic C# such as generics, LINQ, file I/O, etc
	- ASP.Net MVC
	- Razor pages
	- Dependency Injector

Subject Matter
--------------

The HOB application was written to provide Histogram reports(i.e., how many times is something repeated) of adjacent words (i.e., Bigrams) within a given body of text.  

	HOB - Ackronym for "Histogram of Bigrams"

	Text Sample - Text value from which a Histogram could be produced.  All text characters are accepted.  Some characters are ignored.

	Ignored Character - Character that is to be ignored and thus not have an impact on a Histogram

		* Whitespace other than the Char(32)
		* Punctuation
		* Double Quotes
		* Quotes

	Word - Single word of text

	Bigram - Two adjacent Words within a Text Sample

	Histogram - In this context, it is a data structure used to display the counts of integer values from a given domain.  Each value in the data structure
				is referred to as a "bucket" and contains the integer value and the count of the number of times the integer was found in the domain. 
				Note that research was done to determine whether a more generic approach based on the mathematics definition of a histogram, but it was
				determined to be more complicated than is appropriate for this project. 

	Histogram Bucket - this is a data structure used within a Histogram.  In addition to the integer value and count, it can include optional payload such as
					   a Bigram value that corresponds to the integer value.

	Bigram Histogram Report - this provides a Histogram of the Bigrams found in a body of text.  
							  Note that other reports such as a Trigram (3 adjacent words) are possible but have not been implementd. 

Solution
--------

The solution consists of four projects, each of which is described below:

	HOB.Services - provides base functionality, such as report generation, in the form of services which can be instantiated directly (as is done in testing) or
	               added to the .NET Core dependency injector framework (as is done in for the console and web front-ends).

	HOB.Tests - provides units tests that run in xUnit.  Currently, unit tests exist only for the services in the HOB.Services project.  Also, unit tests directly
				instantiate the service objects - this is to be replaced by usage of dependency injector in the near future.

	HOB - console application that allows interactive usage of the HOB services.  When executed, the user may choose to enter a file or to type text at the command prompt.
	      If the user chooses 'F' for file, then the next prompt is for a filename, and when provided, generates a histogram report and prints to the console.  Otherwise,
		  the application enters a loop that prompts the user for text which yields a histogram report is generated for that text and is printed to the console;
		  to exit the loop, the user must enter 'X'.

	HOB.Web - ASP.Net MVC website that allows a user to enter text and generate histogram reports which are rendered to a results page.

	  
HOB.Services
------------

The following distinct services were written and can be used in the dependency injector:

	Cleaning Service - provides method to remove ignored characters from a string.   

	Parsing Service - provides method that splits a string into words using the space character (32) as the delimiter.  

	Bigram Service - provides method to to extract bigrams from a list of words

	Histogram Service - contains methods used to create histograms such as BuildStringDomain() and Generate()

	File Service - encapsulates all interaction with File class.  

	Bigram Histogram Report Service - used to generate Bigram Histogram Reports which include the original text, domain of bigrams, and range of distinct bigrams with counts.  
									  this service has dependencies on the Cleaning, Parsing, Bigram, and Histogram services

Additionally, a generic data structure was created to support creation of histograms.  It is supported by the following:

	Histogram - generic class instantiated with a list of integers that exposes a list of buckets with the histogram results

	IHistogramBucket - interface that defines buckets used in a Histogram class. 

	HistogramBucket - class that implements IHistogramBucket in vanilla fashion.  

	StringHistogramBucket - class that implement IHistogramBucket with an extra string in the payload.
	
HOB.Web
-------

The website was generated from template so there may be some extraneous code included.  This will get pruned out over time.

Also, several times during development, a catastrophic failure was encountered when trying to run the website application from within Visual Studio.  This was repeatable but did not 
happen on any of the other applications in development at the time, so it was appeared to be specific to this project.  Some research was done and the solution appears to be related to some hidden
files related to the solution.  Specifically, the following file appears to have been corrupted in some fashion

	{code repository path }\HOB\.vs\HOB\config\applicationhost.config

To resolve the problem, this file had to be deleted.  Thus, the next time the application is run in Visual Studio, this config file will be rebuilt and thus not corrupted.


	