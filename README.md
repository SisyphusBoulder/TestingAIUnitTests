# TestingAIUnitTests

Effective Usage of AI As A Learning and Programming Tool
AI usage can be an effective teacher and efficient for generating documents and code for our
applications. There are some key rules and best practices we should follow for this, which we
shall explore in this analysis.


<b>Task 1: Unit Tests</b>

In task 1 we allowed the AI to explain, demonstrate, and eventually generate code for unit tests
for our simple customer validation class. We followed some key points while doing this:
- Provide the AI the language/tech stack - this is an easily missed but highly important step as
we need to make sure the AI is aware of the possibilities and limitations of the language or tech
stack we're using, even if we're not generating actual code. We do this so that we can be sure
that any learnings we take away from our experience are relevant and applicable to our use
cases.
- Demonstrate the schema of our customer - By providing the AI model the schema of the
customer we're validating against, we not only prime the AI for intuiting the fields we want
validating, but we also open the option to expand on our unit tests by testing the constructor
and even integration tests. In addition, for using AI in the way I did (i.e. not integrated into the
IDE) showing the member names allows any generated code to seamlessly integrate into my
application.
- Specify the package - somewhat related to the first point, but clearly defining the
packages/libraries we want the AI to use when assessing our query will make for far more
accurate and relevant analysis and code generation; if using external packages, then this step is
just as important as specifying the tech stack.
- Create a plan - a simple plan is a critical piece of context that is incredibly powerful and
helpful with keeping the AI on track. Asking the AI to create a plan with the context we've given it
not only helps the AI stick to the task at hand, but also allows for reflection and consideration on
the developer side to assess whether the plan is good or needs further refinement. We asked it
to generate a plan - simple, since it only needed to generate test classes, but nevertheless is a
great way to keep both the AI and developer in sync with expectations.
- Request a demonstration from the AI - asking the AI to create a single test class allows us to
properly examine it's work, and correct any errors or any formatting/structure that we don't
want. Making any changes we want the AI to carry through high up in the context window will
pay dividends throughout the rest of the time spent working on a particular subject. This also
let's us cross check the solution that AI has come up with; while not too relevant for this
particular use case of unit testing due to the relative simplicity and fairly standard structure of
tests, for more complex tasks ensuring the AI solution is both functional and follows best
practices is a crucial step.
- Consider improvements - there are many cases where the AI will suggest improvements or
changes, often unprompted, based on it's own database of similar subject matters; in this case,
the AI pointed out clearly what would and would not be permitted by the regex patterns, and as
a result I queried it to develop a more robust and comprehensive pattern for names. As always,
this was tested in a regex playground before implementation, and was a successful
improvement from the AI analysis.
- Continuous management - overall, using the AI in small chunks continually monitoring and - if
necessary - course correcting the AI is the best way to use AI. In this case we generated test
cases class by class and tested each one as they were added to the program, which allowed us
to properly determine if the AI was functionally successful. The AI did a solid job in this case and
didn't really require any adjustments; but this was only because we set the stage for success
with the previous steps.


<b>Task 2: Library Integration</b>

In this task I had an idea about how I wanted to do a particular task with a library, but wanted to
assess the validity of my idea. Then, when it came to implementation, I had the AI explain the
fundamentals of what I was trying to do, and further had it analyse the code I had written to help
improve it's functionality:
- Provide tech stack - as task 1, giving the AI the language I was using is the crucial first step to
contextualise everything afterwards
- Thoroughly explain scenario - I try to give the AI as much detail as I can on the implementation
of my code, so that the AI is aware of any limitations or requirements I have. A key point is that I
missed a crucial bit of context when asking about the implementation of a function for my
library - our applications do not have DI containers and implementing one is outside the scope
of the work I was doing, so the AI's suggestions to use dependency injection are actually not
applicable to my use case. A better way to use the AI would be to explain this kind of limitation;
though, it is fair to say that in general, especially when discussing topics that are novel to the
user, it's entirely possible that a user wouldn't even know if a feature such as a DI container is
relevant to the topic at hand.

- Ask about fundamentals - at it's core, AI best serves as a learning tool; it can take a huge
wealth of knowledge and distil it down into a human readable explanation, and can deep dive in
any direction if requested. As a developer, it's important to leverage the AI as a learning tool to
develop their skills, and not rely on the AI (particularly the agentic modes) to create a solution
without developer intervention or understanding.
- Request code analysis - by showing a carefully curated excerpt of my implementation, the AI
was able to analyse what I was doing and suggest improvements/alternatives. Important to keep
the code shared with AI limited if not using a business tier license, to protect company property
and maintain privacy requirements.
- Ask about best practices - while the AI should be reasonably expected to weight good code
over bad code and therefore recommend the better solution, it is often beneficial to explicitly
ask about best practices; not only does this contextualise the request as asking for high quality
code and therefore weight such code more heavily, but many models are also quite verbose and
will provide extra context as to why a particular solution or implementation is better than an
alternative. This is good for both learning experience and also sanity checking the quality of the
AI suggestions.
