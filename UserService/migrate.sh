#!/bin/bash

echo "Running migrations..."

dotnet ef database update

if [ $? -eq 0 ]; then
    echo "Migrations completed successfully!"
else
    echo "Migration failed!"
    exit 1
fi