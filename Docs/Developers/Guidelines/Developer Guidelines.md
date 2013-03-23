SciSharp - Developer Guidelines
===============================

SciSharp is a set of libraries and tools for .NET 4 tailored for
scientific computing. It includes one main library (`SciSharp.dll`)
with the core API, a few smaller libraries which provide alternative
implementations that might not work on your system (for instance,
GPU acceleration), a few utilities and a lot of examples.

SciSharp is a work in progress, and it is still in a very unstable
state, so use it at your own risk. So said, we think it does
contain some helpful and mostly working tools for scientific 
computing applications that may be of interest both for researchers
in academic areas and for developers who want to spice their software
with a bit of extra magic.

It currently encompasses the following areas:

 * Algorithms on graphs, trees and other collections
 * Language Processing
 * Machine Learning
 * Numerical Optimization (exact and heuristic) 
 * Statistics and Probabilities
 * Simulation
 

Collaboration
------------

All interested developers are welcome to collaborate. 
The standard medium of collaboration is by cloning from
[the Github repository](https://github.com/AlejandroPiad/SciSharp.git).

The source code is controlled using Git. If you want to collaborate
you'll need to know at least enough of Git to be able to create your
commits and submit them as patches. Patches can be send either
through Github `pull request` feature or as a mail attachment
to <scisharp-patches@lists.apiad.net>. Please format patches using the Git
tools, and include enough information in the pull request or mail
to make a general idea of the patch content.

Collaboration can be in the form of (compilable) source code,
but also by writing examples, tutorials, or documentation in
general, and by providing services such as packaging and deployment.

Even if you are not a developer with expertise in the areas the 
project covers, such that you cannot write a new algorithm or 
data structure, you can still collaborate by using the library, and
writing documentation or examples to help others learn the how-to.


Coding Guidelines
-----------------

Source code is written in C# using most of the standard coding
rules of the .NET community. To clarify, basic guidelines are
given here. If in doubt, check the existing source code, or ask
one of the older developers. All (compilable) source code is
located in the `Source/` folder. Project wide solutions are located
in this folder root. 

Projects are located in their own folder if they are
a primary output (such as the `SciSharp` project itself that generates
the main library, or the `SciSharp.Console` project). Smaller or 
secondary projects are grouped inside a folder with a common name,
such as the `Source/Implementation/` folder which contains the projects
for alternative implementations to base classes (such as GPU-enabled
algebraic operations) which have stronger requirements than the
main library (like having a GPU, or using third-party libraries).

Inside projects, all first level members (classes, enums, delegates)
should have it's own .cs file, named like the member's name. Where
necessary, a class can be made partial and split across more than 
one file, and secondary files should be named with the class name
plus some extra information that describes the partial content.
For example, the Primes class (which contains static methods for
primality generation and testing) is split in two files: `Primes.cs`
where all methods are, and `Primes16.cs` which contains a static
array with all 16-bit primes. Such a big array would clutter the
`Primes.cs` file, and potentially slowdown IDE tools which tend to
reformat a source file when typing.

A project's file tree should exactly resemble the internal namespace
layout, with namespaces mapping to folders, and keeping the same
nesting.

### Naming guidelines: ###
 
 * Classes, delegates and enums, public members (properties, methods
   and fields), non-private static members, and constants should be
   named in `UpperCamelCase`.
 * Private fields (instance and static) should be named in 
   `lowerCamelCase`.
 * Type argument for generic types should be named in `UpperCamelCase`
   with a `T` prepended, that is `TUpperCamelCase`.
 * Interfaces should be named in `UpperCamelCase` with an `I` 
   prepended, that is `IUpperCamelCase`.
 * In general, no underscores (`_`) should be used in naming, **except** 
   for enabling fluid interfaces features that *look* better with 
   such syntax.
   
### Comments: ###

 * All definitions (public and non-public) should have the 
   corresponding XML comments. At least try to include `<summary/>`,
   all the `<param .../>` and the `<returns/>` tags.  
 * The source itself should be correctly commented as it is widely
   accepted that source code is read many more times than it is
   written. For all non-obvious lines of code, please include 
   sensible comments that explain the intended behavior.
   
    **NOTE**: For descriptions that require a technical or academic language
    it is OK and even encouraged to use LaTeX math markup in
    the comments, both XML comments and inline comments. The
    tools for automatic documentation generation should correctly
    deal with LaTeX source. This includes notations like $O(n)$
    and similar.

### Testing guidelines: ###

Please do your best effort to include unit tests
that cover your contribution's functionality. Unit tests should be
organized in projects in the `Source/Testing/` folder. Tests for a 
specific class (or related group of classes that implement the same
feature) should be contained in a source file named `XYZTest.cs`,
where `XYZ` is a sensible name that describes the tested features
(most commonly the tested class name). Tests are coded using the
standard .NET 4.0 testing framework, and should follow the standard
guidelines. Please do name tests with a name long enough to state the
intended testing result. Group different test classes in projects
according to the tested feature relations. 

As an example, all tests for the library collections are located in
the `/Testing/SciSharp.Testing.Collections` project. The tests for
the `RandomizedHeap` class are grouped in the `RandomizedHeapTests` class.

Documentation is written in different formats, according
to the desired output and intended audience. Big manuals are written
in LaTeX, Online documentation is written in HTML format (that is,
you can generate it with any tool you want that produces HTML), and
small, always changing instructions such as README files, and these
guidelines, are written in plain ASCII text, following the Markdown
markup language. All documentation source is located in the `Docs/` 
folder.


Branching Model
---------------

The source code is controlled using Git. There are two main branches,
named `master` and `develop`. There should be additional branches
for each release, feature or bug fix that requires more than one 
commit.

Commits should be done often and kept as small as possible in the
number of changes they comprise. Always try to make one commit for
a logical change in the source code or documentation. A logical 
change is not necessary a new feature or a bug fix, these could
require a lot of commits. If you are going to implement a new
feature, or fix a bug that is not trivial, create a new branch and
code the entire feature or fix-up there. Then submit it as a patch,
and we'll look at it, and merge it to `develop` once it is completed.

Completed doesn't mean fully tested though, `develop` might have code
that doesn't work, but at least it means that you think the feature
or fix-up is completed. Once it has been sanitized and checked it 
will merged into `master`. New releases will sprout from `master`
at any given point, and the release branch will only be used to
fully polish any remaining bugs. Release branches should be named
`release-x.y.z` for the corresponding version. Tags should be
added in the release branch to mark the release schedule (for
example `version-x.y.z-alpha` or `version-x.y.z-rc1`).

Feature branches should be named `feature-xyz` where `xyz` is
a sensible (and short) name that describes the feature. 
Bug fixup branches should be named `bug-#issue` where 
`#issue` is the number of the reported issue in the bug
tracking list. If you find an issue and code a solution very
fast, before reporting it, then please before sending the
patch or pull request fill in the bug report and rename the
branch accordingly, just for the sake of organization, unless
as said before it is a very small bug with just one commit
that can be fast-forwarded into `develop`.

If you have a very small fix-up (such as a missing null check)
you can code it directly into `develop` and make a single commit.
We will very probably accept it, and thank for it.

If necessary, and in order to not disrupt the coding process,
big documentation changes can be granted a branch of their
own, just as with features. The name should be `doc-xyz`,
again with a sensible explanation of the documentation
change. Documentation changes or additions for new features 
should be done within the same `feature-xyz` branch, 
as the feature it refers to,
in order to keep documentation updated wherever the corresponding
feature goes. This way, when back-porting features or bug fixes
the corresponding documentation should be correctly back-ported
as well.

Developers that wish to will be granted write access to the
repository after sending a few patches, just so that we can confirm
your good will. It's not a matter of distrust, but a spammer with
right access to the repository would be a disaster.


Version Semantics
--------------------

All executable output directly generated by the project (libraries
and applications) should use the same version scheme, and
ideally the same version number (to reduce confusion).

The project uses a standard `major.minor.micro` version format,
with the following semantics:

* Changes in the `micro` number indicate **bug fixes** or any other change
  that doesn't change any public interface or any publicly perceivable
  semantic. It should provide forward and backward transparent
  compatibility.

* Changes in the `minor` number indicate new features and **additions**
  to the public interfaces. It should provide backward compatibility.
  If a new feature needs to change some interface, then the old 
  interface should still be available (for older code to correctly
  compile) and with the corresponding semantics. Such deprecated
  interfaces should be marked with a `DeprecatedAttribute` 
  and removed in the next `major` change.

* Changes in the `major` number indicate a whole redesign of public
  interfaces that might break backward compatibility.

*Alpha*, *Beta* and *RC* versions will be provided (as many
as necessary) for each release, as bugs are discovered and fixed.

#### NOTE ####

Until version `1.0.0` is reached, the previous version scheme is
shifted one position to the right, and the bug-fix number is dropped.
This means that all `0.minor.micro` versions use the minor version 
number to mark compatibility breaking changes, and the micro number 
to mark new features which preserve backward compatibility. As 
previously said, bug-fixes will not be granted a version number 
(since we expect to have so many of them). Once version `1.0.0` is 
reached, the above instructions will take place.

We will only keep an official release (for the time being), to
simplify the maintenance process. Once a new release is published,
the old release will be no longer supported, unless some developer
gratefully takes care of it.

We will do try to release very often, at least until we reach
version `1.0.0`. 


Third Party Software
--------------------

When needed, third party libraries or software can be used to provide
extra functionality. That said, the main library (`SciSharp.dll`) 
which provides all the core functionality should have no third party
dependencies. Specifically, we will not use third party libraries 
which provide algorithms or tools similar to our own, nor will we
code wrappers for very optimized C libraries that do everything we
do but better. SciSharp is written in C#, and all code should be
available on C#, even if a little (or a lot) less optimized.

Alternative implementations may be provided which do use third party
software. For example, there is an alternative implementation of the
algebraic operations (matrices and vectors) which uses GPU 
acceleration through the SlimDX framework. But all functionality
provided in this secondary library is available in a standard C#
implementation in the main library, such that if someone
won't (or can't) use GPU acceleration, it can still use the software 
implementation, that albeit a lot slower, is fully functional.

Third party software needs to be licensed in such a way that allows
us to distribute their compiled binaries (or source, given the case)
with our own license. In general, any OSI approved license should
suffice. Third party libraries will go into the `Contrib/` folder
to be distributed with the source code. They will always be 
included in the repository, to ensure that all clones have the
correct version. They should be included with all the 
corresponding licenses.


Ideas
-----

All ideas are welcome. SciSharp is a library that intends to be big.
Anything related to scientific computing fits here, even if outside
the very general areas we give at the beginning of the document.
If you think you have and idea we might be interested, let us know.
If you can, code it yourself and we will very probably include it,
even if we might make some changes to adapt it to the library's
coding standards, and such.


Copyright
---------

All the SciSharp products (source code, compiled binaries, documentation, examples, tools) are released under the 
[MIT Software License](http://www.opensource.org/licenses/mit-license.php), 
meaning the project is and will always be open source. We will not accept
copyrighted, patented or otherwise certified contributions that are 
incompatible with the open source initiative and spirit. 

Please refrain from adding copyright comments in the source code or 
any other part of your contribution.