namespace Flashcards

open System
open System.Web
open System.Web.Mvc
open System.Web.Routing
open MongoDB.Driver
open MongoDB.Bson
open MongoDB.Bson.Serialization

type Route = { controller : string
               action : string
               id : UrlParameter }

type ListSerializer = 
    inherit IBsonSerializer



type Global() =
    inherit System.Web.HttpApplication() 

    let setupMongo () =
        BsonClassMap.RegisterClassMap<Deck>(fun cm -> 
            cm.AutoMap() |> ignore
            cm.GetMemberMap("Cards").SetRepresentation(BsonType.Array) |> ignore
            ) |> ignore

        BsonClassMap.RegisterClassMap<Card>(fun cm -> 
            cm.AutoMap() |> ignore
            cm.GetMemberMap("Sides").SetRepresentation(BsonType.Array) |> ignore
            ) |> ignore

    static member RegisterRoutes(routes:RouteCollection) =
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.MapRoute("Default", 
                        "{controller}/{action}/{id}", 
                        { controller = "Home"; action = "Index"
                          id = UrlParameter.Optional } )

    member this.Start() =
        setupMongo ()
        AreaRegistration.RegisterAllAreas()
        Global.RegisterRoutes(RouteTable.Routes)