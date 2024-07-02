class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        readChars = set()
        left = 0
        length = 0

        for right in range(len(s)):
            while s[right] in readChars:
                readChars.remove(s[left])
                left += 1
            readChars.add(s[right])
            length = max(length, right - left + 1)
        
        return length
