using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.Enum;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Answers;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Questions;
using Quiz.Domain.Entities.Topics;
using Quiz.Domain.Entities.Users;
using Quiz.Persistence.Context;

public static class DatabaseSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Certificar que o banco existe e está limpo
        context.Database.EnsureCreated();

        var adminAccount = new Account
        {
            Id = Guid.NewGuid(),
            UserName = "admin",
            Password = "root",
            Email = "admin@root.com",
            Type = AccountType.Admin
        };
        context.Accounts.Add(adminAccount);
        context.SaveChanges();


        var admin = new User
        {
            Id = Guid.NewGuid(),
            Name = "Administrador da Plataforma",
            Account = adminAccount,
            AccountId = adminAccount.Id
        };
        context.Users.Add(admin);
        context.SaveChanges();


        // 1. Criar Tópicos
        var topics = new List<Topic>
        {
            new()
            {
                Id = Guid.NewGuid(), Name = "Ciência", Description = "Quizzes sobre Ciências em geral",
                UserId = admin.Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Matemática", Description = "Quizzes de Matemática", UserId = admin.Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "História", Description = "Quizzes sobre História mundial",
                UserId = admin.Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Tecnologia", Description = "Quizzes sobre Tecnologia e Programação",
                UserId = admin.Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Geografia", Description = "Quizzes sobre Geografia mundial",
                UserId = admin.Id
            }
        };

        context.Topics.AddRange(topics);

        // 2. Criar Quizzes, Perguntas e Respostas Reais
        var quizzes = new List<Kwiz>();
        var questions = new List<Question>();
        var answers = new List<Answer>();

        var quizCounter = 0;

        foreach (var topic in topics)
        {
            for (int i = 0; i < 10; i++) // Até 10 quizzes por tópico
            {
                var quizId = Guid.NewGuid();
                var quizName = topic.Name switch
                {
                    "Ciência" => $"Curiosidades Científicas {i + 1}",
                    "Matemática" => $"Desafios de Matemática {i + 1}",
                    "História" => $"Fatos Históricos {i + 1}",
                    "Tecnologia" => $"Fundamentos de Tecnologia {i + 1}",
                    "Geografia" => $"Geografia do Mundo {i + 1}",
                    _ => $"Quiz {i + 1}"
                };

                var quiz = new Kwiz
                {
                    Id = quizId,
                    Name = quizName,
                    MaxPoint = 100,
                    TopicId = topic.Id,
                    UserId = admin.Id
                };

                quizzes.Add(quiz);

                // Adicionar perguntas reais
                var questionData = GetRealQuestionsAndAnswers(topic.Name);

                foreach (var (statement, options) in questionData)
                {
                    var questionId = Guid.NewGuid();
                    var question = new Question
                    {
                        Id = questionId,
                        Statement = statement,
                        QuizId = quizId,
                        Kwiz = quiz
                    };
                    questions.Add(question);

                    // Adicionar respostas reais
                    foreach (var (text, isCorrect) in options)
                    {
                        answers.Add(new Answer
                        {
                            Id = Guid.NewGuid(),
                            Text = text,
                            IsCorrect = isCorrect,
                            QuestionId = questionId
                        });
                    }
                }

                quizCounter++;
                if (quizCounter >= 50) break; // Limite de 50 quizzes
            }

            if (quizCounter >= 50) break; // Parar após 50 quizzes
        }

        context.Kwizzes.AddRange(quizzes);
        context.SaveChanges();

        context.Questions.AddRange(questions);
        context.Answers.AddRange(answers);

        // Salvar mudanças no banco
        context.SaveChanges();
    }

    private static List<(string statement, List<(string text, bool isCorrect)> options)>
        GetRealQuestionsAndAnswers(string topic)
    {
        return topic switch
        {
            "Ciência" => new List<(string, List<(string, bool)>)>
            {
                ("Qual é o elemento químico mais abundante no universo?", new()
                {
                    ("Hidrogênio", true),
                    ("Oxigênio", false),
                    ("Carbono", false),
                    ("Hélio", false)
                }),
                ("Qual é a unidade básica da vida?", new()
                {
                    ("Célula", true),
                    ("Átomo", false),
                    ("Molécula", false),
                    ("Tecido", false)
                }),
                ("Qual é o maior órgão do corpo humano?", new()
                {
                    ("Pulmões", false),
                    ("Pele", true),
                    ("Coração", false),
                    ("Fígado", false)
                }),
                ("Qual gás é essencial para a respiração humana?", new()
                {
                    ("Gás carbônico", false),
                    ("Oxigênio", true),
                    ("Nitrogênio", false),
                    ("Hidrogênio", false)
                }),
                ("Qual é o fenômeno natural responsável pelo arco-íris?", new()
                {
                    ("Reflexão da luz", false),
                    ("Refração da luz", true),
                    ("Dispersão de partículas", false),
                    ("Interferência da luz", false)
                }),
                ("Qual é o planeta conhecido como Planeta Vermelho?", new()
                {
                    ("Júpiter", false),
                    ("Marte", true),
                    ("Saturno", false),
                    ("Vênus", false)
                }),
                ("Qual é a unidade de medida da intensidade da corrente elétrica?", new()
                {
                    ("Volts", false),
                    ("Ampere", true),
                    ("Ohms", false),
                    ("Watts", false)
                }),
                ("O que as plantas absorvem durante a fotossíntese?", new()
                {
                    ("Hidrogênio", false),
                    ("Dióxido de carbono", true),
                    ("Oxigênio", false),
                    ("Nitrogênio", false)
                }),
                ("Qual é o maior órgão do corpo humano?", new()
                {
                    ("Pulmões", false),
                    ("Pele", true),
                    ("Coração", false),
                    ("Fígado", false)
                })
            }.Take(new Random().Next(3, 9)).ToList(),
            "Matemática" => new List<(string, List<(string, bool)>)>
            {
                ("Qual é o valor de π (pi) aproximado?", new()
                {
                    ("3,14", true),
                    ("2,71", false),
                    ("1,62", false),
                    ("4,13", false)
                }),
                ("Quanto é 7 x 8?", new()
                {
                    ("56", true),
                    ("48", false),
                    ("49", false),
                    ("64", false)
                }),
                ("Qual é o valor da integral de x^2 de 0 a 2?", new()
                {
                    ("8/3", true),
                    ("4", false),
                    ("2", false),
                    ("3", false)
                }),
                ("Qual é a fórmula para calcular a área de um círculo?", new()
                {
                    ("πr^2", true),
                    ("2πr", false),
                    ("r^2", false),
                    ("πd", false)
                }),
                ("Quanto é 25 + 37?", new()
                {
                    ("62", true),
                    ("60", false),
                    ("70", false),
                    ("72", false)
                }),
                ("Qual é o valor de 5 elevado a 3?", new()
                {
                    ("125", true),
                    ("100", false),
                    ("150", false),
                    ("75", false)
                }),
                ("Quanto é 144 / 12?", new()
                {
                    ("12", true),
                    ("10", false),
                    ("14", false),
                    ("16", false)
                })
            }.Take(new Random().Next(3, 7)).ToList(),
            "História" => new List<(string, List<(string, bool)>)>
            {
                ("Quem descobriu o Brasil?", new()
                {
                    ("Pedro Álvares Cabral", true),
                    ("Cristóvão Colombo", false),
                    ("Dom Pedro I", false),
                    ("Vasco da Gama", false)
                }),
                ("Em que ano começou a Segunda Guerra Mundial?", new()
                {
                    ("1939", true),
                    ("1914", false),
                    ("1945", false),
                    ("1929", false)
                }),
                ("Quem foi o primeiro presidente dos Estados Unidos?", new()
                {
                    ("George Washington", true),
                    ("Abraham Lincoln", false),
                    ("Thomas Jefferson", false),
                    ("Theodore Roosevelt", false)
                }),
                ("Em que ano o homem pisou na Lua pela primeira vez?", new()
                {
                    ("1969", true),
                    ("1959", false),
                    ("1972", false),
                    ("1980", false)
                }),
                ("Quem foi o imperador romano durante a crucificação de Jesus?", new()
                {
                    ("César Augusto", false),
                    ("Nero", false),
                    ("Tibério", true),
                    ("Trajano", false)
                }),
                ("Quem escreveu a obra 'O Príncipe'?", new()
                {
                    ("Maquiavel", true),
                    ("Voltaire", false),
                    ("Jean-Jacques Rousseau", false),
                    ("Karl Marx", false)
                }),
                ("Qual foi o principal motivo da Revolução Francesa?", new()
                {
                    ("Desigualdade social", true),
                    ("Expansão do império", false),
                    ("Avanços tecnológicos", false),
                    ("Abolição da escravidão", false)
                }),
                ("Quem foi o responsável pela independência do Brasil?", new()
                {
                    ("Dom Pedro I", true),
                    ("Dom João VI", false),
                    ("José Bonifácio", false),
                    ("Napoleão Bonaparte", false)
                })
            }.Take(new Random().Next(3, 8)).ToList(),
            "Tecnologia" => new List<(string, List<(string, bool)>)>
            {
                ("Qual linguagem é usada para desenvolvimento Web Frontend?", new()
                {
                    ("JavaScript", true),
                    ("Python", false),
                    ("C#", false),
                    ("Java", false)
                }),
                ("O que significa HTTP?", new()
                {
                    ("HyperText Transfer Protocol", true),
                    ("High Text Transfer Process", false),
                    ("HyperTool Text Processing", false),
                    ("HyperText Tool Protocol", false)
                }),
                ("O que é o 'Blockchain'?", new()
                {
                    ("Uma rede de computadores", false),
                    ("Uma tecnologia para transações seguras", true),
                    ("Um tipo de criptomoeda", false),
                    ("Um software de programação", false)
                }),
                ("Qual é a principal função de um 'Router'?", new()
                {
                    ("Armazenar dados", false),
                    ("Conectar redes e encaminhar pacotes de dados", true),
                    ("Fornecer endereços IP", false),
                    ("Gerar senhas de Wi-Fi", false)
                }),
                ("Qual linguagem de programação foi criada para desenvolver aplicações para dispositivos móveis da Apple?",
                    new()
                    {
                        ("Swift", true),
                        ("Kotlin", false),
                        ("Java", false),
                        ("C#", false)
                    }),
                ("Qual é o principal serviço de armazenamento em nuvem oferecido pela Amazon?", new()
                {
                    ("Google Drive", false),
                    ("OneDrive", false),
                    ("Amazon S3", true),
                    ("Dropbox", false)
                }),
                ("Quem formulou a teoria da gravitação universal?", new()
                {
                    ("Galileu Galilei", false),
                    ("Isaac Newton", true),
                    ("Albert Einstein", false),
                    ("Nikola Tesla", false)
                }),
                ("Qual é a velocidade da luz no vácuo?", new()
                {
                    ("150.000 km/s", false),
                    ("299.792 km/s", true),
                    ("1.080.000 km/s", false),
                    ("100.000 km/s", false)
                })
            }.Take(new Random().Next(3, 8)).ToList(),
            "Geografia" => new List<(string, List<(string, bool)>)>
            {
                ("Qual é o maior continente do mundo?", new()
                {
                    ("Ásia", true),
                    ("África", false),
                    ("América", false),
                    ("Europa", false)
                }),
                ("Qual é o rio mais longo do mundo?", new()
                {
                    ("Rio Nilo", true),
                    ("Rio Amazonas", false),
                    ("Rio Yangtzé", false),
                    ("Rio Mississipi", false)
                }),
                ("Onde está localizada a Grande Barreira de Coral?", new()
                {
                    ("No Caribe", false),
                    ("Na costa da Austrália", true),
                    ("Na costa do Brasil", false),
                    ("Na África", false)
                }),
                ("Qual é o maior estado brasileiro em termos de área?", new()
                {
                    ("São Paulo", false),
                    ("Minas Gerais", false),
                    ("Amazonas", true),
                    ("Bahia", false)
                }),
                ("Qual é o maior país do mundo em termos de área?", new()
                {
                    ("China", false),
                    ("Rússia", true),
                    ("Canadá", false),
                    ("Brasil", false)
                }),
                ("Qual é o nome do maior deserto do mundo?", new()
                {
                    ("Deserto do Saara", false),
                    ("Deserto de Gobi", false),
                    ("Antártida", true),
                    ("Deserto de Atacama", false)
                }),
                ("Qual país é o maior produtor de petróleo do mundo?", new()
                {
                    ("Estados Unidos", true),
                    ("Arábia Saudita", false),
                    ("Rússia", false),
                    ("Venezuela", false)
                }),
                ("Qual é o nome do maior lago de água doce do mundo?", new()
                {
                    ("Lago Baikal", false),
                    ("Lago Superior", true),
                    ("Lago Titicaca", false),
                    ("Lago Vitória", false)
                })
            }.Take(new Random().Next(3, 8)).ToList(),
            _ => new List<(string, List<(string, bool)>)>()
        };
    }
}