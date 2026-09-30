workspace "asm-architecture" "Modelo C4 do sistema" {

    model {
        user = person "Usuário" "Usuário do sistema"

        system = softwareSystem "Sistema ASM" "Descrição do sistema" {
            webapp = container "Web App" "Interface do usuário" "SPA"
            api = container "API" "Regras de negócio" "REST"
            db = container "Banco de Dados" "Persistência" "PostgreSQL" "Database"
        }

        user -> webapp "Usa"
        webapp -> api "Consome" "HTTPS/JSON"
        api -> db "Lê e escreve" "SQL"
    }

    views {
        systemContext system "Contexto" {
            include *
            autolayout lr
        }

        container system "Containers" {
            include *
            autolayout lr
        }

        styles {
            element "Person" {
                shape person
            }
            element "Database" {
                shape cylinder
            }
        }
    }
}
