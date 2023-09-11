# Composite Dictionary Library

## Introduction
The Composite Dictionary library provides an implementation of nested dictionaries, which allow for more intuitive and organized data access based on multiple key hierarchies. 
Which is especially beneficial when you need to manage complex data relationships without flattening or complicating key structures.

# Archived
This project has been archived, potentially on a temporary basis, due to a couple of critical considerations:

- Niche Usage: Composite dictionaries serve a very niche purpose and may not be beneficial for a broad range of applications.
- Potential for Bad Practice: Utilizing composite dictionaries can sometimes encourage practices that overlook the importance of properly hashing custom structs or utilizing tuples, which are well-handled in C# natively.

## Why Use Composite Dictionary?
- Multi-key Access: Instead of relying on concatenated or composite keys, this library allows for a structured way to access values using multiple discrete keys.

- Simplified Syntax: The TryGetValue method, along with others provided in the library, offers a clean syntax for handling complex nested retrieval operations.

- Clear Error Handling: Using the Try-pattern, it is straightforward to handle scenarios where data might not be found for a given set of keys.

## When to Use It?

- Multi-level Configuration is Needed: If you're dealing with configurations that are environment-specific, machine-specific, and user-specific, this library provides a way to organize and retrieve these settings hierarchically.

- Hierarchical Caching: When caching data that can be categorized under multiple tiers, Composite Dictionary offers a neat way to structure and retrieve this data.

## Alternatives and When to Consider Them

### Flat Dictionary with Composite Keys

- Description: This approach involves creating a single composite key from multiple key components, which can be used as the primary key in a standard dictionary.
- Best Suited For: Scenarios where memory efficiency is a primary concern, or where the set of keys is predictable and remains relatively static. This method can also be useful when the total number of unique key combinations is not exceedingly large.
- Advantages: It has the potential for faster access times due to fewer layers of lookup, and memory overhead can be reduced by eliminating nested structures.

### Databases with Multi-field Indexing

- Description: Databases can store vast amounts of data and provide efficient querying mechanisms, especially when multiple fields are indexed.
- Best Suited For: Use cases requiring persistent storage of large datasets, or where advanced querying capabilities (like joins, aggregations, or filters) are needed.
- Advantages: Scalability, persistence, backup, and concurrent access support. Databases like SQLite, PostgreSQL, and MongoDB offer multi-field indexing and can handle complex queries efficiently.

### Trie or Prefix Tree Structures:

- Description: A Trie is a tree-like data structure that stores dynamic sets of associative strings, where the keys are usually strings.
Best Suited For: Scenarios involving large datasets of strings where prefix searches, like auto-complete features, are frequently performed.
- Advantages: Efficient storage for strings, particularly when many strings share the same prefixes. They can lead to faster lookup times for certain search operations compared to other data structures.
It's essential to evaluate the specific needs and constraints of your application before choosing the most suitable data structure or approach.

## Getting Started

### Setup
```csharp
// PrimaryKey: School Name
// SecondaryKey: Subject
// ThirdKey: TestID
// Value: Student's Score
var schoolResults = new NestedDictionary<string, string, int, int>();
```
### Fetching
```csharp
// You have the ability to use it normally as "nested" dictionaries, which is a little unsafer:
schoolResults["Green High"]["Math"][101] = 95;  // Set the result of the Math test with ID 101 in Green High to 95.

int score = schoolResults["Green High"]["Math"][101];  // Get the result of the Math test with ID 101 in Green High.

// Type safety

schoolResults.TryGetValue("Green High", "Math", 101, out int value);
```
Using direct access through brackets can lead to potential runtime errors if a key doesn't exist. On the other hand, 
the TryGetValue method offers a safer approach that doesn't throw exceptions for non-existent keys but instead uses an out parameter to return the value.



### Keys
```csharp
// Retrieve All Subjects for a School
var subjects = schoolResults.GetSecondaryKeys("Green High").ToList();

// Fetch All Test IDs for a Subject in a School:
var testIDs = schoolResults.GetThirdKeys("Green High", "Math").ToList();

// Check if exists for all keys such as, if Green High school exists.
bool exists = schoolResults.ContainsPrimary("Green High");


```

### Merge


```csharp
var anotherDictionary = new NestedDictionary<string, string, int, int>();
// ... (populate this dictionary)
schoolResults.Merge(anotherDictionary);
```
The Merge function combines the contents of anotherDictionary into schoolResults. If there are any overlapping keys, the values from anotherDictionary will overwrite those in schoolResults.
