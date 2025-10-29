# NIM Solution for CS354

As per specification, Minimax was the algorithm implemented. However, Minimax is surprisingly slow, as time complexity 
is O(piles ^ pile size). A better option, as Jackson proposed, is to take the bitwise XOR method on the binary numbers 
and find what the most effective pile to take from that would be.