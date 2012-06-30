namespace Flashcards

open MongoDB.Bson
open MongoDB.Bson.Serialization
open MongoDB.Bson.Serialization.Attributes

type Side() =
    member val Text = "" with get, set

type Card() = 
    member val Sides : Side list = [] with get, set

type Deck() =  
    member val Id = BsonObjectId.GenerateNewId() with get, set
    member val Cards : Card list = [] with get, set
    member val Title = "N/A" with get, set
