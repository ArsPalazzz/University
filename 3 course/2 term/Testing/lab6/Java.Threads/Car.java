class Car extends Thread {
    private final ParkingLot parkingLot;
    private final long maxWaitTime;

    public Car(String name, ParkingLot parkingLot, long maxWaitTime) {
        super(name);
        this.parkingLot = parkingLot;
        this.maxWaitTime = maxWaitTime;
    }

    @Override
    public void run() {
        try {
            System.out.println(getName() + " arrived at the parking lot.");
            if (parkingLot.tryPark(maxWaitTime)) {
                System.out.println(getName() + " parked successfully.");
                Thread.sleep((long) (Math.random() * 5000)); // Simulating time spent in the parking lot
                System.out.println(getName() + " left the parking lot.");
                parkingLot.leave();
            } else {
                System.out.println(getName() + " couldn't park and left.");
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
