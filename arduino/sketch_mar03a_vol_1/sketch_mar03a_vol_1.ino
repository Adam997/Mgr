void setup() {
  // put your setup code here, to run once:
  
Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  
// read the input on analog pin 0:
  //int sensorValue = analogRead(A2);
 
    int maly = analogRead(A2);
    int serdeczny = analogRead(A3);
    int srodkowy = analogRead(A4);
    int wskazujacy = analogRead(A5);
   
  // Convert the analog reading (which goes from 0 - 1023) to a voltage (0 - 5V):
  //float voltage = sensorValue * (5.0 / 1023.0);
  
    float voltage1 = maly * (5.0 / 1023.0);
    float voltage2 = serdeczny * (5.0 / 1023.0);
    float voltage3 = srodkowy * (5.0 / 1023.0);
    float voltage4 = wskazujacy * (5.0 / 1023.0);
   
  // print out the value you read:
  Serial.print(round(voltage4));
  Serial.print('\t');
  Serial.print(round(voltage3));
  Serial.print('\t');
  Serial.print(round(voltage2));
  Serial.print('\t');
  Serial.print(round(voltage1));
  Serial.print("\t n \t");
  Serial.println('\n');
}
