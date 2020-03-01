int voltage = 0;
bool on = false;

void setup() 
{
  Serial.begin(9600);
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);
}

void loop() 
{
  voltage = analogRead(A0);

  if (voltage > 1000)
  {
    on = true;
    digitalWrite(12, LOW);
    digitalWrite(13, HIGH);
  }

  else
  {
    on = false;
    digitalWrite(13, LOW);
    digitalWrite(12, HIGH);
  }
  
  Serial.println(on);
}
