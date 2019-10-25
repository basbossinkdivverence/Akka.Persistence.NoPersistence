# Akka.Persistence.NoPersistence

An [Akka.net Persistence plugin][plug] that provides no persistence
whatsoever.

## Why is this useful?

If you have a reusable compontent/actor that was designed to be
persistent but you want to reuse the given actor in a non-persistent
manner. Using the builtin in memory persistence keeps all received
messages in memory causing the memory usage of the application to grow
over the lifetime of the execution of the application. This
persistence plugin implements an `AsyncJournal` and a `SnapshotStore`
that store and therefor recover nothing and always succeed at
doing that 😉.


## Usage

1. Add the package reference:
   ```sh
   dotnet add package Akka.Persistence.NoPersistence 
   ````
2. Configure your application as described [here][plug]:
   ```bash
    akka.persistence {
        journal {
            plugin = "akka.persistence.journal.none"
            # No persistence journal plugin.
            none {
                # Class name of the plugin.
                class = "Akka.Persistence.NoPersistence.EmptyJournal, Akka.Persistence.NoPersistence"
                # Dispatcher for the plugin actor.
                plugin-dispatcher = "akka.actor.default-dispatcher"
            }
        }
        snapshot-store {
            plugin = "akka.persistence.snapshot-store.none"
            # No persistence snapshot-store plugin.
            none {
                # Class name of the plugin.
                class = "Akka.Persistence.NoPersistence.EmptySnapshotStore, Akka.Persistence.NoPersistence"
                # Dispatcher for the plugin actor.
                plugin-dispatcher = "akka.actor.default-dispatcher"
            }
        }
   ```

## License

This work is licensed under the LGPL license, refer to the
[COPYING.md][license] and [COPYING.LESSER.md][licenseExtension] files
for details.

[license]: COPYING
[licenseExtension]: COPYING.LESSER
[plug]: https://getakka.net/articles/persistence/storage-plugins.html
