using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;

public record CreateCategoryCommand(string CategoryName) : IRequest;


  //geriye bişey donmeyeck response gerek yok sadece bos kalsin










