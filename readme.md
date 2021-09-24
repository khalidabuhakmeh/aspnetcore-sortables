# Sortable with Templates

This repository is exploring how to bind complex collections using
ASP.NET Core facilities while maintaining elements like validation,
data annotation attributes, and other metadata.

Also using ASP.NET Core to generate server-side templates for client-side
additions. This is pretty common for expanding and unbounded collections like
todo lists, grocery lists, well... lists!

You might argue that an extra web request to generate a clientside template is 
wasteful. I say, well... maybe, but I get the HTML generated by the server
with all the necessary metadata and I don't have to keep them in sync. I could
also generate it clientside. 

Anyways. This can maintain order, even when those items are sorted.

You're welcome internet and ASP.NET Core devs!