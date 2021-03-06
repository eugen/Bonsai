default: all

all: build test doc

clean:
	-rm -rf bin

### TESTS
test : bin/Bonsai.Tests.dll
	-rm bin/testresults.xml
	@MSTest.exe -noisolation -nologo -resultsfile:bin/testresults.xml -testcontainer:"bin/Bonsai.Tests.dll" -detail:errormessage -detail:errorstacktrace -detail:stdout

### DOC
TEX=xelatex -quiet
doc : bin/bonsai.pdf

bin/bonsai.bst : doc/bonsai.bst
	-mkdir bin
	cp doc/bonsai.bst bin/bonsai.bst

bin/bonsai.bbl : bin/bonsai.bst doc/bonsai.bib
	cd bin && $(TEX) ../doc/bonsai.tex 
	cp doc/bonsai.bib bin/bonsai.bib
	cd bin && bibtex bonsai

bin/bonsai.pdf : bin/bonsai.bbl doc/bonsai.tex
	cd bin && $(TEX) ../doc/bonsai.tex

### SLIDES
TEX=xelatex -quiet
slides : bin/slides.pdf

bin/slides.pdf : doc/slides.tex
	cd bin && $(TEX) ../doc/slides.tex

### BUILDS
build: bin/Bonsai.Parser.dll bin/Bonsai.Runtime.dll bin/Bonsai.Tests.dll

bin/Bonsai.Parser.dll : src/Parser/*.cs src/Parser/**/*.cs
	MSBuild.exe -nologo src/Parser/Parser.csproj

bin/Bonsai.Runtime.dll : src/Runtime/*.cs src/Runtime/**/*.cs
	MSBuild.exe -nologo src/Runtime/Runtime.csproj

bin/Bonsai.Tests.dll : src/Tests/*.cs src/Tests/**/*.cs
	MSBuild.exe -nologo src/Tests/Tests.csproj
