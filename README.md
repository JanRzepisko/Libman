
# Libman
System do zarządzania biblioteką (For Fun). Projekt składa się z 3 mikroserwisów 
## Struktura Projektu 
 - Projekt jest podzielony na Mikro serwisy i projekt Shared
 - Każdy projekt w solucji jest oparty od .NET 7
 - Serwis powinien  składać się z 4 warstw
	| Warstwa  |  Wyjaśnienie  |  Udostępnione elementy | Typ
	|--|--|--|--| 
	| API | Zawiera kontrolery, pliki Program.cs i Strtup.cs, appsettings | Shared, Application, Infrastructure | Interfej API 
	| Infrastructure | Zawiera DbContext serwisu, pliki migracji, customowe repozytoria dla każdego serwisu | Shared, Application | Biblioteka rozszerzeń NET 7
	| Application | Zawiera plik IUnitOfWork, Handlery, plik AssemblyEntryPoint.cs | Shared, Domain | Biblioteka rozszerzeń NET 7
	| Domain | Zwiera Typy , struktury enumy oraz Modele Encji | Shared | Biblioteka rozszerzeń NET 7


## Wykorzystane Technologie
| Problem | Pakiet |
|---|---|
| Mediator | Mediator |
| Walidacja | FluentValidation |
| Baza Danych | MySql | 
| Message Broker | RabbitMQ |
| Data | Entity Framework |

## Handler

- Przykładowy Handler
	```csharp
        using FluentValidation;  
	    using Identity.Application.DataAccess;  
	    using MediatR;  
      
	    namespace Identity.Application.Actions.Command.User;  
      
	    public static class RegisterUser  
	    {  
		    public sealed record Command(string Name, string Surname, string Email, string Password, string ConfirmPassword) : 	IRequest<Unit>;  
	        public class Handler : IRequestHandler<Command, Unit>  
		    {  
	            private readonly IUnitOfWork _unitOfWork;  
      
	            public Handler(IUnitOfWork unitOfWork)  
	            {  
	                _unitOfWork = unitOfWork;  
	            }  
      
	            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)  
	            {  
	                await _unitOfWork.Users.AddAsync(new Domain.Entities.User()  
				     {  
	                    Password = request.Password,  
	                    Email = request.Email,  
	                    Name = request.Name,  
	                    Surname = request.Surname  
	                }, cancellationToken);  
                  
	                await _unitOfWork.SaveChangesAsync(cancellationToken);  
	                return Unit.Value;  
		        }	  
      
	            public sealed class Validator : AbstractValidator<Command>  
		        {  
	                public Validator()  
	                {  
	                    RuleFor(c => c.Password).Equal(c => c.ConfirmPassword);  
	                }  
	            }  
	        }  
	    }


## Controller 
- Controller dziedziczy z klasy **BaseApiController** z Shared

```csharp
		using Identity.Application.Actions.Command.User;  
		using MediatR;  
		using Microsoft.AspNetCore.Mvc;  
		using Shared.BaseModels.ApiControllerModels;  
  
		namespace Identity.API.Controller;  
  

		[Authorize(JwtPolicies.Admin)]
		[ApiController]
		[Route("Book")]
		public class BookController : BaseApiController
		{
		    public BookController(IMediator mediator) : base(mediator) { }
		    
		    [HttpPost]
		    public Task<IActionResult> Endpoint(CreateBook.Command request) => base.Endpoint(request);        
		    [HttpPut]
		    public Task<IActionResult> Endpoint(UpdateBook.Command request) => base.Endpoint(request);        
		    [HttpDelete]
		    public Task<IActionResult> Endpoint(RemoveBook.Command request) => base.Endpoint(request);    
		    [HttpGet]
		    public Task<IActionResult> Endpoint(string searchString, int page, Guid LibraryId) => base.Endpoint(new GetBook.Command(searchString, page, LibraryId));    
		    
		}

```

## Reposiotry

- Interfejs Repozytoriów są deklarowane w warstwie Application a ich implementacje Infrastructure
- Każde Repozytorium musi dziedziczyć z BaseRepository<TEntity>
