int voltageA = 0;
int voltageB = 0;
int voltageC = 0;
int voltageD = 0;
int voltageSwitch = 0;

bool onA = false;
bool onB = false;
bool onC = false;
bool onD = false;

char input;

void setup() 
{
  Serial.begin(9600);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);
}

void loop() 
{
  voltageA = analogRead(A0);
  voltageB = analogRead(A1);
  voltageC = analogRead(A2);
  voltageD = analogRead(A3);
  voltageSwitch = analogRead(A5);

  if (Serial.available() > 0) 
  {
    input = Serial.read();
    
    if (input = "R")
    {
      Serial.print(onA);
      Serial.print(onB);
      Serial.print(onC);
      Serial.println(onD);
    } 
  }

  
  if (voltageA > 1000)
  {
    if (voltageSwitch > 1000)
    {
      onA = true;     
    }

    else
    {
      onA = false;     
    }   
  }

  else if (voltageB > 1000)
  {
    if (voltageSwitch > 1000)
    {
      onB = true;
    }

    else
    {
      onB = false;
    }   
  }

  else if (voltageC > 1000)
  {
    if (voltageSwitch > 1000)
    {
      onC = true;
    }

    else
    {
      onC = false;
    }   
  }

  else if (voltageD > 1000)
  {
    if (voltageSwitch > 1000)
    {
      onD = true;
    }

    else
    {
      onD = false;
    }
  }

  if (onA)
  {
    digitalWrite(12, LOW);
    digitalWrite(13, HIGH);
  }

  else
  {
    digitalWrite(12, HIGH);
    digitalWrite(13, LOW);
  }

  if (onB)
  {
    digitalWrite(10, LOW);
    digitalWrite(11, HIGH);
  }

  else
  {
    digitalWrite(10, HIGH);
    digitalWrite(11, LOW);
  }

  if (onC)
  {
    digitalWrite(8, LOW);
    digitalWrite(9, HIGH);
  }

  else
  {
    digitalWrite(8, HIGH);
    digitalWrite(9, LOW);
  }

  if (onD)
  {
    digitalWrite(6, LOW);
    digitalWrite(7, HIGH);
  }

  else
  {
    digitalWrite(6, HIGH);
    digitalWrite(7, LOW);
  }

  delay(50);
}
