# LINQ Performance Analysis Report
* **Repository:** `https://github.com/dotnet/eShop.git`
* **Branch:** `main`
* **Total Issues:** 115

### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:183`
```csharp
Assert.Equal("Wanderer Black Hiking Boots", result.Data.ToList().FirstOrDefault().Name)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal("Wanderer Black Hiking Boots", result.Data.ToList().FirstOrDefault().Name)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:183`
```csharp
Assert.Equal("Wanderer Black Hiking Boots", result.Data.ToList().FirstOrDefault().Name)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal("Wanderer Black Hiking Boots", result.Data.ToList().FirstOrDefault().Name)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:183`
```csharp
result.Data.ToList().FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Data.ToList().FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:211`
```csharp
Assert.Contains("Alpine", result.Data.ToList().FirstOrDefault().Name)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Contains("Alpine", result.Data.ToList().FirstOrDefault().Name)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:211`
```csharp
Assert.Contains("Alpine", result.Data.ToList().FirstOrDefault().Name)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Contains("Alpine", result.Data.ToList().FirstOrDefault().Name)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:211`
```csharp
result.Data.ToList().FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Data.ToList().FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:284`
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogTypeId)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogTypeId)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:284`
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogTypeId)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogTypeId)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:284`
```csharp
result.Data.ToList().FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Data.ToList().FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:285`
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:285`
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:285`
```csharp
result.Data.ToList().FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Data.ToList().FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:313`
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:313`
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assert.Equal(3, result.Data.ToList().FirstOrDefault().CatalogBrandId)
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/Catalog.FunctionalTests/CatalogApiTests.cs:313`
```csharp
result.Data.ToList().FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Data.ToList().FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/Ordering.FunctionalTests/OrderingApiTests.cs:202`
```csharp
payload.Items.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
payload.Items.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Ordering.Infrastructure/MediatorExtension.cs:11`
```csharp
domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.Infrastructure/MediatorExtension.cs:11`
```csharp
domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Ordering.Infrastructure/MediatorExtension.cs:11`
```csharp
domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Ordering.Infrastructure/MediatorExtension.cs:15`
```csharp
domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents())
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents())
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.Infrastructure/MediatorExtension.cs:15`
```csharp
domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents())
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents())
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Ordering.Infrastructure/MediatorExtension.cs:15`
```csharp
domainEntities.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
domainEntities.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF002] N+1 Query Pattern in Foreach Loop
* **Location:** `src/eShop.ServiceDefaults/OpenApiOptionsExtensions.cs:74`
```csharp
foreach (var link in policy.Links.Where(l => l.Type == "text/html"))
                {
                    if (!rendered...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
foreach (var link in policy.Links.Where(l => l.Type == "text/html"))
                {
                    if (!rendered...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/eShop.ServiceDefaults/OpenApiOptionsExtensions.cs:110`
```csharp
options.AddOperationTransformer((operation, context, cancellationToken) =>
        {
            var metadata = context....
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
options.AddOperationTransformer((operation, context, cancellationToken) =>
        {
            var metadata = context....
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/eShop.ServiceDefaults/OpenApiOptionsExtensions.cs:110`
```csharp
options.AddOperationTransformer((operation, context, cancellationToken) =>
        {
            var metadata = context....
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
options.AddOperationTransformer((operation, context, cancellationToken) =>
        {
            var metadata = context....
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/eShop.ServiceDefaults/OpenApiOptionsExtensions.cs:129`
```csharp
scopes.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
scopes.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/eShop.ServiceDefaults/OpenApiOptionsExtensions.cs:129`
```csharp
scopes.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
scopes.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/ClientApp.UnitTests/Services/BasketServiceTests.cs:11`
```csharp
result.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/ClientApp.UnitTests/Services/OrdersServiceTests.cs:30`
```csharp
result.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
result.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/ClientApp.UnitTests/Services/CatalogServiceTests.cs:12`
```csharp
catalog.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
catalog.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/ClientApp.UnitTests/Services/CatalogServiceTests.cs:21`
```csharp
catalogBrand.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
catalogBrand.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `tests/ClientApp.UnitTests/Services/CatalogServiceTests.cs:30`
```csharp
catalogType.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
catalogType.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Services/CatalogAI.cs:41`
```csharp
embeddings.Select(m => new Vector(m.Vector[0..EmbeddingDimensions])).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
embeddings.Select(m => new Vector(m.Vector[0..EmbeddingDimensions])).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Catalog.API/Services/CatalogAI.cs:41`
```csharp
embeddings.Select(m => new Vector(m.Vector[0..EmbeddingDimensions])).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
embeddings.Select(m => new Vector(m.Vector[0..EmbeddingDimensions])).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Infrastructure/CatalogContextSeed.cs:30`
```csharp
context.CatalogBrands.AddRangeAsync(sourceItems.Select(x => x.Brand).Distinct()
                .Where(brandName => bran...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogBrands.AddRangeAsync(sourceItems.Select(x => x.Brand).Distinct()
                .Where(brandName => bran...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Catalog.API/Infrastructure/CatalogContextSeed.cs:33`
```csharp
context.CatalogBrands.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogBrands.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Infrastructure/CatalogContextSeed.cs:36`
```csharp
context.CatalogTypes.AddRangeAsync(sourceItems.Select(x => x.Type).Distinct()
                .Where(typeName => typeNam...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogTypes.AddRangeAsync(sourceItems.Select(x => x.Type).Distinct()
                .Where(typeName => typeNam...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Catalog.API/Infrastructure/CatalogContextSeed.cs:39`
```csharp
context.CatalogTypes.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogTypes.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Infrastructure/CatalogContextSeed.cs:46`
```csharp
sourceItems
                .Where(source => source.Name != null && source.Brand != null && source.Type != null)
       ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
sourceItems
                .Where(source => source.Name != null && source.Brand != null && source.Type != null)
       ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Catalog.API/Infrastructure/CatalogContextSeed.cs:72`
```csharp
context.CatalogItems.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogItems.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:77`
```csharp
api.MapGet("/catalogtypes",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applicat...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/catalogtypes",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applicat...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:77`
```csharp
api.MapGet("/catalogtypes",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applicat...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/catalogtypes",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applicat...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:79`
```csharp
context.CatalogTypes.OrderBy(x => x.Type).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogTypes.OrderBy(x => x.Type).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:79`
```csharp
context.CatalogTypes.OrderBy(x => x.Type).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogTypes.OrderBy(x => x.Type).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:84`
```csharp
api.MapGet("/catalogbrands",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applica...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/catalogbrands",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applica...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:84`
```csharp
api.MapGet("/catalogbrands",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applica...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/catalogbrands",
            [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "applica...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:86`
```csharp
context.CatalogBrands.OrderBy(x => x.Brand).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogBrands.OrderBy(x => x.Brand).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:86`
```csharp
context.CatalogBrands.OrderBy(x => x.Brand).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CatalogBrands.OrderBy(x => x.Brand).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:138`
```csharp
root.Where(c => c.Name.StartsWith(name))
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
root.Where(c => c.Name.StartsWith(name))
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:152`
```csharp
root
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            ....
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
root
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            ....
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:152`
```csharp
root
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            ....
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
root
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            ....
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:166`
```csharp
services.Context.CatalogItems.Where(item => ids.Contains(item.Id)).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems.Where(item => ids.Contains(item.Id)).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:166`
```csharp
services.Context.CatalogItems.Where(item => ids.Contains(item.Id)).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems.Where(item => ids.Contains(item.Id)).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:166`
```csharp
services.Context.CatalogItems.Where(item => ids.Contains(item.Id))
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems.Where(item => ids.Contains(item.Id))
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:266`
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .Select(c => new { Item =...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .Select(c => new { Item =...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:266`
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .Select(c => new { Item =...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .Select(c => new { Item =...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:276`
```csharp
itemsWithDistance.Select(i => i.Item).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
itemsWithDistance.Select(i => i.Item).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:276`
```csharp
itemsWithDistance.Select(i => i.Item).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
itemsWithDistance.Select(i => i.Item).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:280`
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .OrderBy(c => c.Embedding...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .OrderBy(c => c.Embedding...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:280`
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .OrderBy(c => c.Embedding...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .OrderBy(c => c.Embedding...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Catalog.API/Apis/CatalogApi.cs:280`
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .OrderBy(c => c.Embedding...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
services.Context.CatalogItems
                .Where(c => c.Embedding != null)
                .OrderBy(c => c.Embedding...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/ClientApp/ViewModels/CheckoutViewModel.cs:98`
```csharp
orders.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
orders.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/ClientApp/Validations/ValidatableObject.cs:38`
```csharp
.Where(v => !v.Check(Value))
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
.Where(v => !v.Check(Value))
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/WebApp/Services/BasketState.cs:35`
```csharp
(await FetchBasketItemsAsync()).Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
(await FetchBasketItemsAsync()).Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/WebApp/Services/BasketState.cs:35`
```csharp
(await FetchBasketItemsAsync()).Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
(await FetchBasketItemsAsync()).Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/WebApp/Services/BasketState.cs:60`
```csharp
(await FetchBasketItemsAsync()).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
(await FetchBasketItemsAsync()).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/WebApp/Services/BasketState.cs:60`
```csharp
(await FetchBasketItemsAsync()).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
(await FetchBasketItemsAsync()).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/WebApp/Services/BasketState.cs:60`
```csharp
(await FetchBasketItemsAsync()).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
(await FetchBasketItemsAsync()).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/WebApp/Services/BasketState.cs:73`
```csharp
basketService.UpdateBasketAsync(existingItems.Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList())
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
basketService.UpdateBasketAsync(existingItems.Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList())
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/WebApp/Services/BasketState.cs:73`
```csharp
existingItems.Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
existingItems.Select(i => new BasketQuantity(i.ProductId, i.Quantity)).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Webhooks.API/IntegrationEvents/OrderStatusChangedToPaidIntegrationEventHandler.cs:12`
```csharp
subscriptions.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
subscriptions.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Webhooks.API/IntegrationEvents/OrderStatusChangedToShippedIntegrationEventHandler.cs:12`
```csharp
subscriptions.Count()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
subscriptions.Count()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Webhooks.API/Services/GrantUrlTesterService.cs:22`
```csharp
tokenValues.FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
tokenValues.FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Webhooks.API/Services/WebhooksRetriever.cs:7`
```csharp
db.Subscriptions.Where(s => s.Type == type).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
db.Subscriptions.Where(s => s.Type == type).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Webhooks.API/Services/WebhooksRetriever.cs:7`
```csharp
db.Subscriptions.Where(s => s.Type == type).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
db.Subscriptions.Where(s => s.Type == type).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Webhooks.API/Apis/WebHooksApi.cs:13`
```csharp
api.MapGet("/", async (WebhooksContext context, ClaimsPrincipal user) =>
        {
            var userId = user.GetUser...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/", async (WebhooksContext context, ClaimsPrincipal user) =>
        {
            var userId = user.GetUser...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Webhooks.API/Apis/WebHooksApi.cs:13`
```csharp
api.MapGet("/", async (WebhooksContext context, ClaimsPrincipal user) =>
        {
            var userId = user.GetUser...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/", async (WebhooksContext context, ClaimsPrincipal user) =>
        {
            var userId = user.GetUser...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Webhooks.API/Apis/WebHooksApi.cs:13`
```csharp
api.MapGet("/", async (WebhooksContext context, ClaimsPrincipal user) =>
        {
            var userId = user.GetUser...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
api.MapGet("/", async (WebhooksContext context, ClaimsPrincipal user) =>
        {
            var userId = user.GetUser...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Webhooks.API/Apis/WebHooksApi.cs:16`
```csharp
context.Subscriptions.Where(s => s.UserId == userId).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.Subscriptions.Where(s => s.UserId == userId).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Webhooks.API/Apis/WebHooksApi.cs:16`
```csharp
context.Subscriptions.Where(s => s.UserId == userId).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.Subscriptions.Where(s => s.UserId == userId).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/IntegrationEventLogEF/Services/IntegrationEventLogService.cs:13`
```csharp
Assembly.Load(Assembly.GetEntryAssembly().FullName)
            .GetTypes()
            .Where(t => t.Name.EndsWith(name...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
Assembly.Load(Assembly.GetEntryAssembly().FullName)
            .GetTypes()
            .Where(t => t.Name.EndsWith(name...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/IntegrationEventLogEF/Services/IntegrationEventLogService.cs:21`
```csharp
_context.Set<IntegrationEventLogEntry>()
            .Where(e => e.TransactionId == transactionId && e.State == EventSta...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
_context.Set<IntegrationEventLogEntry>()
            .Where(e => e.TransactionId == transactionId && e.State == EventSta...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/IntegrationEventLogEF/Services/IntegrationEventLogService.cs:21`
```csharp
_context.Set<IntegrationEventLogEntry>()
            .Where(e => e.TransactionId == transactionId && e.State == EventSta...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
_context.Set<IntegrationEventLogEntry>()
            .Where(e => e.TransactionId == transactionId && e.State == EventSta...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Services/ProfileService.cs:16`
```csharp
subject.Claims.Where(x => x.Type == "sub").FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
subject.Claims.Where(x => x.Type == "sub").FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Identity.API/Services/ProfileService.cs:23`
```csharp
claims.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
claims.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Identity.API/Services/ProfileService.cs:23`
```csharp
claims.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
claims.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Services/ProfileService.cs:23`
```csharp
claims.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
claims.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Services/ProfileService.cs:30`
```csharp
subject.Claims.Where(x => x.Type == "sub").FirstOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
subject.Claims.Where(x => x.Type == "sub").FirstOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Services/ProfileService.cs:39`
```csharp
subject.Claims.Where(c => c.Type == "security_stamp").Select(c => c.Value).SingleOrDefault()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
subject.Claims.Where(c => c.Type == "security_stamp").Select(c => c.Value).SingleOrDefault()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `tests/Ordering.UnitTests/Domain/SeedWork/ValueObjectTests.cs:148`
```csharp
c.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
c.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `tests/Ordering.UnitTests/Domain/SeedWork/ValueObjectTests.cs:148`
```csharp
c.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
c.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF002] N+1 Query Pattern in Foreach Loop
* **Location:** `src/Catalog.API/IntegrationEvents/EventHandling/OrderStatusChangedToAwaitingValidationIntegrationEventHandler.cs:15`
```csharp
foreach (var orderStockItem in @event.OrderStockItems)
        {
            var catalogItem = catalogContext.CatalogIte...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
foreach (var orderStockItem in @event.OrderStockItems)
        {
            var catalogItem = catalogContext.CatalogIte...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF002] N+1 Query Pattern in Foreach Loop
* **Location:** `src/Catalog.API/IntegrationEvents/EventHandling/OrderStatusChangedToPaidIntegrationEventHandler.cs:13`
```csharp
foreach (var orderStockItem in @event.OrderStockItems)
        {
            var catalogItem = catalogContext.CatalogIte...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
foreach (var orderStockItem in @event.OrderStockItems)
        {
            var catalogItem = catalogContext.CatalogIte...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Ordering.API/Application/Behaviors/ValidatorBehavior.cs:23`
```csharp
validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
          ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
          ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.API/Application/Behaviors/ValidatorBehavior.cs:23`
```csharp
validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
          ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
          ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Ordering.API/Application/Behaviors/ValidatorBehavior.cs:23`
```csharp
validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
          ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
          ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.API/Application/Queries/OrderQueries.cs:27`
```csharp
order.OrderItems.Select(oi => new Orderitem
            {
                ProductName = oi.ProductName,
                ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
order.OrderItems.Select(oi => new Orderitem
            {
                ProductName = oi.ProductName,
                ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Ordering.API/Application/Queries/OrderQueries.cs:27`
```csharp
order.OrderItems.Select(oi => new Orderitem
            {
                ProductName = oi.ProductName,
                ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
order.OrderItems.Select(oi => new Orderitem
            {
                ProductName = oi.ProductName,
                ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.API/Application/Queries/OrderQueries.cs:39`
```csharp
context.Orders
            .Where(o => o.Buyer.IdentityGuid == userId)  
            .Select(o => new OrderSummary
     ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.Orders
            .Where(o => o.Buyer.IdentityGuid == userId)  
            .Select(o => new OrderSummary
     ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Ordering.API/Application/Queries/OrderQueries.cs:39`
```csharp
context.Orders
            .Where(o => o.Buyer.IdentityGuid == userId)  
            .Select(o => new OrderSummary
     ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.Orders
            .Where(o => o.Buyer.IdentityGuid == userId)  
            .Select(o => new OrderSummary
     ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.API/Application/Queries/OrderQueries.cs:52`
```csharp
context.CardTypes.Select(c=> new CardType { Id = c.Id, Name = c.Name }).ToListAsync()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
context.CardTypes.Select(c=> new CardType { Id = c.Id, Name = c.Name }).ToListAsync()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Ordering.API/Application/Commands/CreateOrderCommand.cs:70`
```csharp
basketItems.ToOrderItemsDTO().ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
basketItems.ToOrderItemsDTO().ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.API/Application/Commands/CreateOrderCommand.cs:70`
```csharp
basketItems.ToOrderItemsDTO().ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
basketItems.ToOrderItemsDTO().ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Ordering.Domain/AggregatesModel/OrderAggregate/Order.cs:161`
```csharp
OrderItems
                .Where(c => orderStockRejectedItems.Contains(c.ProductId))
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
OrderItems
                .Where(c => orderStockRejectedItems.Contains(c.ProductId))
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Identity.API/Quickstart/Account/AccountController.cs:231`
```csharp
schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
           ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
           ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Quickstart/Account/AccountController.cs:231`
```csharp
schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
           ...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
           ...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Identity.API/Quickstart/Account/AccountController.cs:249`
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Identity.API/Quickstart/Account/AccountController.cs:249`
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Quickstart/Account/AccountController.cs:249`
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF005] Client-Side Evaluation Trap
* **Location:** `src/Identity.API/Quickstart/Account/AccountController.cs:249`
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme))
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme))
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [LINQ003] Missing Projection (.Select)
* **Location:** `src/Identity.API/Quickstart/Account/ExternalController.cs:148`
```csharp
externalUser.Claims.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
externalUser.Claims.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Identity.API/Quickstart/Account/ExternalController.cs:148`
```csharp
externalUser.Claims.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
externalUser.Claims.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Identity.API/Quickstart/Account/ExternalController.cs:148`
```csharp
externalUser.Claims.ToList()
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
externalUser.Claims.ToList()
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF001] Missing AsNoTracking() in Read-Only Query
* **Location:** `src/Ordering.API/Application/IntegrationEvents/EventHandling/OrderStockRejectedIntegrationEventHandler.cs:10`
```csharp
@event.OrderStockItems
            .FindAll(c => !c.HasStock)
            .Select(c => c.ProductId)
            .ToList(...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
@event.OrderStockItems
            .FindAll(c => !c.HasStock)
            .Select(c => c.ProductId)
            .ToList(...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
### ⚠️ [EF004] Synchronous DB Call in Async Method
* **Location:** `src/Ordering.API/Application/IntegrationEvents/EventHandling/OrderStockRejectedIntegrationEventHandler.cs:10`
```csharp
@event.OrderStockItems
            .FindAll(c => !c.HasStock)
            .Select(c => c.ProductId)
            .ToList(...
```

**AI Recommendation:**
### 💡 AI Root Cause Analysis
AI Evaluation Error: HTTP 403: <!doctype html><meta charset="utf-8"><meta name=viewport content="width=device-width, initial-scale=1"><title>403</title>403 Forbidden

### ⚡ Performance Impact


### 🛠️ Refactored Solution
```csharp
@event.OrderStockItems
            .FindAll(c => !c.HasStock)
            .Select(c => c.ProductId)
            .ToList(...
```

### 📌 Recommendation
Review manual refactoring guidelines.

---
