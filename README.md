# json-super-compress
A Way to intelligently compress json data for large datasets.

Large Json Datasets tend to have a lot of repetition in the documents. Especially lists of objects. 
For example. locations, org Names, person names, enumerations, database foreign-keys etc.

A (Very bad, but tiny) Example.
```
data = [
{
    Project: "Tim's bakery",
    Assigned to: "Mark Robinson",
    Status: In-Progress,
    Category: "Small and medium Business",
    CategoryId: 54
}
,{
    Project: "Jons's Saloon",
    Assigned to: "Mark Robinson",
    Status: In-Progress,
    Category: "Small and medium Business",
    CategoryId: 54
}
,{
    Project: "Starbucks LA",
    Assigned to: "Catherine Hepburn",
    Status: Closing,
    Category: "Enterprise",
    CategoryId: 55
},
.........THOUSANDS of similar records.
]
```

Assume, now:
1. There are 10 Staff Members.
2. 5 Status Types
3. 6 Categories.

But each item in the list, will need to "spell out" the above EVERY TIME.

Instead, Let's compress it, intelligently.
```
packed_data = 
{
   // Let's compress the attribute names, while we're at it. JSONC style baby!
   SCHEMA_MAP:{
      p:"Project",
      at: "AssignedTo",
      ss: "Status",
      ct: "Category",
      ci: "CategoryId"
   },
   // Now let's figure out the enumerations based on the attribute values, checking for duplicates.
   ENUMS:{
      p: null, // No sense in doing projects, since they are not repeating as much, so we'll be putting 1000s of names here. 
      at: ["Mark Robinson", "Catherine Hepburn", "James Dean", "Will Smith", "Mark Ruffallo"] // Watched hulk again.. sorry.
      ss: ["Pipeline","Bidding","In-Progress","Lost","Closing", "Done", "Abandoned"]
      ct: ["Small and Medium Business", "Entreprise", "Millitary", "Government","Puny Individual"]
      ci: [54,55,54,43,23] 
   },
   P_DATA:[
     {p:"Tim's Bakery",at:0,ss:2,ct:0,cti:0}, // PUT IN INDEX POSITIONS OF THE ENUM LIST, DEFINED ABOVE.
     {p: "Jons's Saloon",at:0,ss:2,ct:0,ci:0},
     {p: "Starbucks LA",at:1,ss:4,ct:1,ci:1},
     ..... 1000s of tiny strings like above.
   ]
}
```
So, with an overhead of SCHEMA_MAP and ENUMS, 
which obviously WILL MAKE NO SENSE FOR SMALL DATA SETS!! (Please just don't),
potential for compression is HUGE.

We're talking:
----------------------
```
{
    Project: "Tim's bakery",
    Assigned to: "Mark Robinson",
    Status: In-Progress,
    Category: "Small and medium Business",
    CategoryId: 54
}
,{
    Project: "Jons's Saloon",
    Assigned to: "Mark Robinson",
    Status: In-Progress,
    Category: "Small and medium Business",
    CategoryId: 54
}
,{
    Project: "Starbucks LA",
    Assigned to: "Catherine Hepburn",
    Status: Closing,
    Category: "Enterprise",
    CategoryId: 55
}
```
(AROUND 449 BYTES)

-------TO ==> 
```
{p:"Tim's Bakery",at:0,ss:2,ct:0,cti:0},
{p: "Jons's Saloon",at:0,ss:2,ct:0,ci:0},
{p: "Starbucks LA",at:1,ss:4,ct:1,ci:1},
```
(AROUND 123 BYTES)

A COMPRESSION RATIO OF : 75%. (Discounting the overhead, of course)

- And then of-course, you'll do some GZIP on it, won't you, you freak.
- Of course you will.

So? Interested Yet?

K, I'm gonna do a initial implementation using C# (.NET) for packing and javascript for unpack, because I need it for a paying project.
Feel free to contribute for more languages.

I'm good at C#, and I'm learning to be better at javascript (At the time of writing this, I don't even know what-the-F is Prototype in JS, but I've heard about it, so that's Good)

Feel free to completely F-up my javascript code. 
C# implementations, I'll be monitoring more closely and will be more picky about pulls and code-quality about since I know some shit there.

















