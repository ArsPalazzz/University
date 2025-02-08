import java.util.concurrent.*;

public class ParkingLot {
    private final int capacity;
    private final Semaphore semaphore;

    public ParkingLot(int capacity) {
        this.capacity = capacity;
        this.semaphore = new Semaphore(capacity, true); // true для обеспечения справедливости (FIFO)
    }

    public boolean tryPark(long maxWaitTime) throws InterruptedException {
        return semaphore.tryAcquire(maxWaitTime, TimeUnit.MILLISECONDS);
    }

    public void leave() {
        semaphore.release();
    }
}